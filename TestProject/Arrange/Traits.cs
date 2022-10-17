using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnit.Introduction;
using Xunit;

namespace TestProject.Arrange
{
    public class Traits
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

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_DoesNotIncludeZero()
        {
            var cal = new Calculations();

            Assert.All(cal.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_Includes13()
        {
            var calc = new Calculations();

            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_DoesNotInclude()
        {
            var calc = new Calculations();

            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            var calc = new Calculations();

            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }
    }
}
