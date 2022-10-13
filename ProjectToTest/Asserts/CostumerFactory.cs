using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToTest.Asserts
{
    public static class CostumerFactory
    {
        public static Costumer CreateCustomerInstance(int orderCount)
        {
            if (orderCount <= 5)
                return new Costumer();
            else
                return new LoyalCostumer();
        }
    }
}
