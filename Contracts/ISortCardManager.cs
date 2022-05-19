using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelDemoAPI.Contracts
{
    public interface ISortCardManager
    {
        public Task<string> GetSortedCards(List<string> inputCardList);
    }
}
