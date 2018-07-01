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
        private LogAnalyzer logAnalyzer = null;

        [SetUp]
        public void SetUp()
        {
            logAnalyzer = new LogAnalyzer();
        }

        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.foo", false)]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string fileName, bool expectedResult)
        {
            bool result = logAnalyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        public void IsValidLogFileName_EmptyFileName_Throws()
        {
            var ex = Assert.Catch<Exception>(() => logAnalyzer.IsValidLogFileName(""));
            StringAssert.Contains("filename has to be provided", ex.Message);
        }

        [TearDown]
        public void TearDown()
        {
            // antipattern
            logAnalyzer = null;
        }
    }
}
