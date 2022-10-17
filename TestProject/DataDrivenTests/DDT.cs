using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.DataDrivenTests
{
    public class DDT
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

        [Fact]
        public void IsOdd_GivenOddValue_ReturnTrue()
        {
            var calc = new Calculations();
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnTrue()
        {
            var calc = new Calculations();
            var result = calc.IsOdd(200);
            Assert.False(result);
        }

        [Theory]
        //[InlineData(1, true)]
        //[InlineData(200, false)]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        //[MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        [IsOddOrEvenData]
        public void IdOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = new Calculations();
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }
    }
}
