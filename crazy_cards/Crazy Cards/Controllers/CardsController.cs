using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Crazy_Cards.Models;

/// <summary>
/// Namespace:      Crazy_Cards
/// Class:          CardsController
/// Type:           Controller
/// Description:    This is the controller that handles available card models
/// </summary>
namespace Crazy_Cards.Controllers
{
    public class CardsController : ApiController
    {
        // Initialize available cards
        private Card[] cards = new Card[]
        {
            new Card { ID = 1,
                       Name = "Student Life Card",
                       APR = 18.9,
                       BTOD = 0,
                       POD = 6,
                       CreditAvailable = 1200 },
            new Card { ID = 2,
                       Name = "Anywhere Card",
                       APR = 33.9,
                       BTOD = 0,
                       POD = 0,
                       CreditAvailable = 300 },
            new Card { ID = 3,
                       Name = "Liquid Card",
                       APR = 33.9,
                       BTOD = 12,
                       POD = 6,
                       CreditAvailable = 3000 }
        };

        [Route("api/cards/")]
        // Return all cards available
        public IEnumerable<Card> GetAllCards()
        {
            return cards;
        }

        [Route("api/cards/{income}/{status}/")]
        // Return all cards that fullfil the criteria
        public IHttpActionResult GetAvailableCards(decimal income, int status)
        {
            // Add to My Cards the default card that anyone can get ("Anywhere Card")
            var myCards = new List<Card>(cards.Where((c) => c.ID == 2));

            // If user is employed or student add the "Student Life Card"
            if (status > 0 && status < 3)
            {
                myCards.Add(cards[0]);
            }

            // If user has an income > £1600 then add the "Liquid Card"
            if (income > 1600)
            {
                myCards.Add(cards[2]);
            }
            
            return Ok(myCards);
        }
    }
}
