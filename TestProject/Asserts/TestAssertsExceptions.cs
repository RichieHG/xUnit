using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsExceptions
    {
        [Fact]
        public void GetOrdersByName_NotNull()
        {
            var costumer = new Costumer();

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
