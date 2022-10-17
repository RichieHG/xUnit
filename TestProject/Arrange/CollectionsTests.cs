using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Arrange
{
    [Collection("Costumer")]
    public class CollectionsTests
    {
        private CostumerFixture _costumerFixture;

        public CollectionsTests(CostumerFixture costumerFixture)
        {
            _costumerFixture = costumerFixture;    
        }

        [Fact]
        public void CheckNameNotEmpty()
        {
            var costumer = _costumerFixture.Costumer;

            Assert.NotNull(costumer.Name);
            Assert.True(!string.IsNullOrEmpty(costumer.Name));
        }

        [Fact]
        public void CheckAgeIsValid()
        {
            int minAge = 18;
            int maxAge = 26;

            var costumer = _costumerFixture.Costumer;

            Assert.InRange(costumer.Age, minAge, maxAge);
        }

        [Fact]
        public void LoyalCostumerForOrdersGraterThan5()
        {
            var costumer = CostumerFactory.CreateCustomerInstance(8);

            //Assert.IsType(typeof(LoyalCostumer), costumer);
            //Assert.IsType<LoyalCostumer>(costumer); //Generics

            var loyalCostumer = Assert.IsType<LoyalCostumer>(costumer);
            Assert.Equal(10, loyalCostumer.Discount);


        }

        [Fact]
        public void GetOrdersByName_NotNull()
        {
            var costumer = _costumerFixture.Costumer;

            //Using Delegates
            //Assert.Throws<ArgumentException>(delegate ()
            //{
            //    costumer.GetOrdersByName("Ricardo");
            //});

            var exceptionDetails = Assert.Throws<ArgumentException>(() => costumer.GetOrdersByName(""));
            Assert.Equal("Hello", exceptionDetails.Message);

        }
    }
}
