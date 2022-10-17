using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xUnit.Introduction;
using Xunit;
using Xunit.Abstractions;

namespace TestProject.Arrange
{
    public class CalculatorFixture: IDisposable
    {
        public Calculator Calculator => new Calculator();
        public Calculations Calculations => new Calculations();
    
        public void Dispose()
        {
            //
        }
    }
    public class FixturesAndDisposable: IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream _memoryStream;

        public FixturesAndDisposable(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("Constructor");
            _calculatorFixture = calculatorFixture;
            _memoryStream = new MemoryStream();
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            _testOutputHelper.WriteLine("Add_GivenTwoIntValues_ReturnsInt");

            var cal = _calculatorFixture.Calculator;
            var result = cal.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            _testOutputHelper.WriteLine("AddDouble_GivenTwoDoubleValues_ReturnsDouble");

            var cal = _calculatorFixture.Calculator;
            var result = cal.AddDouble(1.2, 2.53);

            Assert.Equal(3.72, result,0);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_DoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("FiboNumbers_DoesNotIncludeZero");

            var cal = _calculatorFixture.Calculations;

            Assert.All(cal.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_Includes13()
        {
            _testOutputHelper.WriteLine("FiboNumbers_Includes13");

            var calc = _calculatorFixture.Calculations;

            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboNumbers_DoesNotInclude()
        {
            _testOutputHelper.WriteLine("FiboNumbers_DoesNotInclude");

            var calc = _calculatorFixture.Calculations;

            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine("CheckCollection");

            var expectedCollection = new List<int> { 1, 1, 2, 3, 5, 8, 13 };
            var calc = _calculatorFixture.Calculations;

            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        /* xUnit automatically checks if IDisposable are implented
         * and call Dispose method at the end.
        */
        public void Dispose()
        {
            _memoryStream.Close();
        }
    }
}
