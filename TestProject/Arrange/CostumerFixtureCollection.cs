using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Arrange
{
    [CollectionDefinition("Costumer")]
    public class CostumerFixtureCollection : ICollectionFixture<CostumerFixture>
    {

    }
}
