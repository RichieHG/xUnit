using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsCollections
    {
        [Fact]
        public void FiboNumbers_DoesNotIncludeZero()
        {
            var cal = new Calculations();

            Assert.All(cal.FiboNumbers, n => Assert.NotEqual(0,n));
        }

        [Fact]
        public void FiboNumbers_Includes13()
        {
            var calc = new Calculations();

            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        public void FiboNumbers_DoesNotInclude()
        {
            var calc = new Calculations();

            Assert.DoesNotContain(4,calc.FiboNumbers);
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
