using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsString
    {
        [Fact]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Neftali", "Hernandez");

            //Assert.Equal("Neftali Hernandez", result);
            //Assert.Equal("Neftali Hernandez", result, ignoreCase:true); //Disable CaseSensitive

            //Assert.Contains("Hernandez", result);
            //Assert.Contains("heRnandez", result, StringComparison.InvariantCultureIgnoreCase); //Disable CaseSensitive

            //Assert.StartsWith("Neftali", result);
            //Assert.StartsWith("neftali", result, StringComparison.InvariantCultureIgnoreCase); //Disable CaseSensitive

            //Assert.EndsWith("Hernandez", result);
            //Assert.EndsWith("HernandeZ", result, StringComparison.InvariantCultureIgnoreCase); //Disable CaseSensitive

            Assert.Matches("[A-z]+ [A-z]+", result);
        
        }
    }
}
