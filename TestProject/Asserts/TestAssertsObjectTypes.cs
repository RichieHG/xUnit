using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsObjectTypes
    {
        [Fact]
        public void LoyalCostumerForOrdersGraterThan5()
        {
            var costumer = CostumerFactory.CreateCustomerInstance(8);
            
            //Assert.IsType(typeof(LoyalCostumer), costumer);
            //Assert.IsType<LoyalCostumer>(costumer); //Generics

            var loyalCostumer =  Assert.IsType<LoyalCostumer>(costumer);
            Assert.Equal(10, loyalCostumer.Discount);


        }
    }
}
