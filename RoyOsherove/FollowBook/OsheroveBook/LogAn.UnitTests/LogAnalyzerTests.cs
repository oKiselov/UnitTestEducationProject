using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.foo", false)]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName, bool expectedResult)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
