using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnit.Introduction;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsNumeric
    {
        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var cal = new Calculator();
            var result = cal.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var cal = new Calculator();
            var result = cal.AddDouble(1.2, 2.53);

            Assert.Equal(3.72, result,0);
        }
    }
}
