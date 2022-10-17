using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectToTest.Asserts
{
    public class Costumer
    {
        public string Name => "Neftali";
        public int Age => 26;

        public int GetOrdersByName(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentException("Hello");

            return 10;
        }

        public string GetFullName(string firstName, string lastName) => $"{firstName} {lastName}";
    }
}
