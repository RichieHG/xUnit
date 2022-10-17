using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DataDrivenTests
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOrEvenData
        {
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false };
            }
        }

        public static IEnumerable<object[]> IsOddOrEvenExternalData
        {
            get
            {
                var allLines = File.ReadAllLines("DataDrivenTests/IsOddOrEvenTestData.txt");
                return allLines.Select(x =>
                {
                    var lineSplited = x.Split(',');
                    return new object[] { int.Parse(lineSplited[0]), bool.Parse(lineSplited[1]) };
                });
            }
        }
    }
}
