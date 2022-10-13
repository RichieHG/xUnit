using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToTest.Asserts
{
    public class LoyalCostumer : Costumer
    {
        public int Discount { get; set; }

        public LoyalCostumer()
        {
            Discount = 10;
        }
    }
}
