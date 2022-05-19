using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelDemoAPI
{
    public class Card
    {
        public int Id { get; set; }

        public string CardValue { get; set; }

        public int SuitValue { get; set; }
        public string SuitName { get; set; }
    }
}
