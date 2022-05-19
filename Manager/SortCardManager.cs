using IntelDemoAPI.Contracts;
using IntelDemoAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelDemoAPI.Manager
{
    public class SortCardManager : ISortCardManager
    {
        public async Task<string> GetSortedCards(List<string> inputCardList)
        {
            List<Card> setOfCards = new List<Card>();

            var orderToBeSorted = new List<string> { "4T", "2T", "ST", "PT", "RT" };

            var intersectedItems = orderToBeSorted.Intersect(inputCardList);
            var notIntersectedItems = inputCardList.Except(orderToBeSorted);

            foreach (var card in notIntersectedItems)
            {
                //Set Card value as there can be alphabets as well as numbers in index 0 - 3C or JS
                int cardValue = 0;

                if (Char.IsDigit(card[0]))
                {
                    cardValue = int.Parse(card[0].ToString());
                }
                else
                {
                    cardValue = (int)Enum.Parse(typeof(CardValue), card[0].ToString());
                }

                //check if the value is 10
                if(card[0] == '1')
                {
                    setOfCards.Add(new Card { 
                        Id = 10, 
                        CardValue = "10", 
                        SuitName = card[2].ToString(), 
                        SuitValue = (int)Enum.Parse(typeof(CardSuit), card[2].ToString())
                });

                }
                else
                setOfCards.Add(new Card { 
                    Id = cardValue, 
                    CardValue = card[0].ToString(), 
                    SuitName = card[1].ToString(),
                    SuitValue = (int)Enum.Parse(typeof(CardSuit), card[1].ToString())
                });
            }

            setOfCards = setOfCards.OrderBy(CardSuit => CardSuit.SuitValue).ThenBy(CardSuit => CardSuit.Id).ToList();

            var notIntersectedNewList = setOfCards.Select(x => new { x.CardValue, x.SuitName });

            List<string> newList = new List<string>();

            foreach (var item in notIntersectedNewList)
            {
                var str = item.CardValue + item.SuitName;
                newList.Add(str);
            }

            var sortedList = intersectedItems.Concat(newList).ToList();

            var finalList = string.Join(", ", sortedList.Select(x => x));

            return finalList;
        }
    }
}
