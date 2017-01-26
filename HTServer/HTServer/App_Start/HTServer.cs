/*
    Hyper Trader Server (HTServer)

    Coded by: George Delaportas (G0D)

*/

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using CPM_STARS___Trade_Server.Models;

namespace CPM_STARS___Trade_Server.App_Start
{
    public static class HTServer
    {
        // Create new status panel instance
        private static StatusPanel NewStatusPanel = new StatusPanel();

        // Run the server
        public static void Run()
        {
            NewStatusPanel.TradeInfoTuples = new Dictionary<int, Dictionary<CurrencyIDType, List<double>>>();
            NewStatusPanel.AggregatedTradeInfo = new List<TradeInfo>();
            NewStatusPanel.AvgFlags = new List<int>();
            NewStatusPanel.CurrenciesValues = Enum.GetValues(typeof(CurrencyIDType));
            NewStatusPanel.ProcessesCount = 10;
            NewStatusPanel.MaxNumOfTuples = 5000;

            // Initialize trade info tuples list
            InitializeTradeInfoTuplesList();

            // Initialize aggregated info list
            InitializeAggregatedInfoList();

            // Enable hyper-threading (multi core support)
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            // Start all generation tuples threads with the brand new TPL scheduler
            Parallel.For(0, NewStatusPanel.ProcessesCount, parallelOptions, index => { GenerateTuplesDelegate(index); });

            // Aggregation thread goes byitself
            Thread AggregateDataThread = new Thread(new ThreadStart(AggregateData));
            AggregateDataThread.Start();

            // Avg thread for average statistics
            Thread AvgStatsThread = new Thread(new ThreadStart(AvgStats));
            AvgStatsThread.Start();
        }

        // Fetch all results
        public static List<TradeInfo> ReturnAggregatedResults()
        {
            return NewStatusPanel.AggregatedTradeInfo;
        }

        private static void InitializeTradeInfoTuplesList()
        {
            for (var process = 0; process < NewStatusPanel.ProcessesCount; process++)
            {
                var newTuples = new Dictionary<CurrencyIDType, List<double>>();

                foreach (CurrencyIDType currIDType in NewStatusPanel.CurrenciesValues)
                {
                    var CurrentValuesList = new List<double>();

                    CurrentValuesList.Add(0.0);

                    newTuples.Add(currIDType, CurrentValuesList);
                }

                NewStatusPanel.TradeInfoTuples.Add(process, newTuples);
            }
        }

        private static void InitializeAggregatedInfoList()
        {
            for (var i = 0; i < Enum.GetNames(typeof(CurrencyIDType)).Length; i++)
            {
                NewStatusPanel.AggregatedTradeInfo.Add(new TradeInfo());

                NewStatusPanel.AvgFlags.Add(0);
            }
        }

        private static void GenerateTuplesDelegate(int ThreadIndex)
        {
            Thread GenerateTuplesThread = new Thread(new ParameterizedThreadStart(GenerateTuples));
            GenerateTuplesThread.Start(ThreadIndex);
        }

        private static void GenerateTuples(object ThreadIndex)
        {
            Random RandomInterval = new Random();
            Random RandomRate = new Random();

            while (true)
            {
                int SleepInterval = RandomInterval.Next(10, 100);
                Thread.Sleep(SleepInterval);

                foreach (CurrencyIDType currIDType in NewStatusPanel.CurrenciesValues)
                {
                    double randomRateValue = Math.Round((RandomRate.NextDouble() * 10.0), 2);

                    // Clear after 5.000 records
                    if (NewStatusPanel.TradeInfoTuples[(int)ThreadIndex][currIDType].Count >= NewStatusPanel.MaxNumOfTuples)
                        NewStatusPanel.TradeInfoTuples[(int)ThreadIndex][currIDType].Clear();

                    NewStatusPanel.TradeInfoTuples[(int)ThreadIndex][currIDType].Add(randomRateValue);
                }
            }
        }

        private static void AggregateData()
        {
            while (true)
            {
                int CurrencyIDIndex = 0;
                List<double> TuplesListValues = new List<double>();
                List<double> AllValuesPerCurrency = new List<double>();

                foreach (CurrencyIDType currIDType in NewStatusPanel.CurrenciesValues)
                {
                    TuplesListValues.Clear();
                    AllValuesPerCurrency.Clear();

                    for (var process = 0; process < NewStatusPanel.ProcessesCount; process++)
                    {
                        TuplesListValues = NewStatusPanel.TradeInfoTuples[process][currIDType];

                        for (var i = 0; i < TuplesListValues.Count(); i++)
                            AllValuesPerCurrency.Add(TuplesListValues[i]);
                    }

                    NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].LastUpdateTime = DateTime.Now;
                    NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].CurrencyID = currIDType.ToString();
                    NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].LastValue = AllValuesPerCurrency.Last();

                    if (NewStatusPanel.AvgFlags[CurrencyIDIndex] == 1)
                    {
                        NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].MaxValue = AllValuesPerCurrency.Max();
                        NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].MinValue = AllValuesPerCurrency.Min();
                        NewStatusPanel.AggregatedTradeInfo[CurrencyIDIndex].AverageValue = Math.Round(AllValuesPerCurrency.Average(), 2);

                        NewStatusPanel.AvgFlags[CurrencyIDIndex] = 0;
                    }

                    CurrencyIDIndex++;
                }
            }
        }

        private static void AvgStats()
        {
            while (true)
            {
                for (var i = 0; i < Enum.GetNames(typeof(CurrencyIDType)).Length; i++)
                    NewStatusPanel.AvgFlags[i] = 1;

                Thread.Sleep(10000);
            }
        }
    }
}
