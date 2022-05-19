using IntelDemoAPI.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelDemoAPI.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CardSortController: ControllerBase
    {
        private readonly ISortCardManager _sortCardManager = null;
        public CardSortController(ISortCardManager sortCardManager)
        {
            _sortCardManager = sortCardManager;
        }

        //[HttpGet("SortCards/{inputCardList}")]
        [HttpGet("SortCards/{inputCardList}")]
        public async Task<IActionResult> SortCards(string inputCardList)
        {
            //string inputCardList = "3C,JS,2D,PT,10H,KH,8S,4T,AC,4H,RT";
            var list = inputCardList.Split(',').ToList();
            var res = await _sortCardManager.GetSortedCards(list);

            return Ok(res);
        }
    }
}
