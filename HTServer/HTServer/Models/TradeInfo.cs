/*
    Hyper Trader Server (HTServer)

    Coded by: George Delaportas (G0D)

*/

using System;
using System.Collections.Generic;

namespace CPM_STARS___Trade_Server.Models
{
    // TradeInfo model
    public class TradeInfo
    {
        public string CurrencyID { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public double LastValue { get; set; }
        public double MaxValue { get; set; }                // Over 10 secs 
        public double MinValue { get; set; }                // Over 10 secs
        public double AverageValue { get; set; }            // Over 10 secs
    }

    // CurrencyIDType model
    public enum CurrencyIDType
    {
        EUR,
        USD,
        GBP,
        DKK,
        HKD,
        ILS
    }

    // StatusPanel model
    public class StatusPanel
    {
        public Dictionary<int, Dictionary<CurrencyIDType, List<double>>> TradeInfoTuples { get; set; }
        public List<TradeInfo> AggregatedTradeInfo { get; set; }
        public List<int> AvgFlags { get; set; }
        public Array CurrenciesValues { get; set; }
        public int ProcessesCount { get; set; }
        public int MaxNumOfTuples { get; set; }
    }
}
