using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestProject.Arrange
{
    [Collection("Costumer")]
    public class CollectionsDataTests
    {
        private CostumerFixture _costumerFixture;

        public CollectionsDataTests (CostumerFixture costumerFixture)
        {
            _costumerFixture = costumerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            var costumer = _costumerFixture.Costumer;
            Assert.Equal("Ricardo Hernandez", costumer.GetFullName("Ricardo", "Hernandez"));
        }
    }
}
