using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Namespace:      Crazy_Cards
/// Class:          Card
/// Type:           Model
/// Description:    This is the model to store and retrieve available cards
/// </summary>
namespace Crazy_Cards.Models
{
    public class Card
    {
        public int ID { get; set; }                                 // Unique ID of Card (Internal use only)
        public string Name { get; set; }                            // Name
        public double APR { get; set; }                             // Annual Percentage Rate (APR)
        public int BTOD { get; set; }                               // Balance Transfer Offer Duration
        public int POD { get; set; }                                // Purchace Offer Duration
        public decimal CreditAvailable { get; set; }                // Available Credit
    }
}
