using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToTest.Asserts
{
    public class Calculations
    {
        public List<int> FiboNumbers => new List<int> { 1, 1, 2, 3, 5, 8, 13 };

        public bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
