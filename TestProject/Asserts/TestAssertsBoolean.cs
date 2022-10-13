using ProjectToTest.Asserts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Asserts
{
    public class TestAssertsBoolean
    {
        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            //names.NickName = "El tuercas"; //Fails because NickName is not null anymore.

            Assert.Null(names.NickName);
        }

        [Fact]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Neftali", "Hernandez");

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
            Assert.False(string.IsNullOrEmpty(result));
        }
    }
}
