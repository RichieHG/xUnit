using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsRangeOfValues
    {
        [Fact]
        public void CheckNameNotEmpty()
        {
            var costumer = new Costumer();

            Assert.NotNull(costumer.Name);
            Assert.True(!string.IsNullOrEmpty(costumer.Name));        }

        [Fact]
        public void CheckAgeIsValid()
        {
            int minAge = 18;
            int maxAge = 26;

            var costumer = new Costumer();

            Assert.InRange(costumer.Age, minAge, maxAge);
        }
    }
}
