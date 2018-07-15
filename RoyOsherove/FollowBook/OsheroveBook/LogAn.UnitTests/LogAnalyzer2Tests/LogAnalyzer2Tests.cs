using Chapter2.LogAnalyzer2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.LogAnalyzer2Tests
{
    // fake objects combination: 1 - stub, 2 - mock
    // WITHOUT NSubstitute
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_Logger2Throws_CallsWebSerivce()
        {
            FakeWebService2 mockWebService = new FakeWebService2();
            FakeLogger2 stubLogger = new FakeLogger2();
            stubLogger.WillThrow = new Exception("fake Exception");

            var analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer2.MinNameLength = 8;

            string tooShortfileName = "abc.txt";
            analyzer2.Analyze(tooShortfileName);

            Assert.That(mockWebService.MessageToWebService, Is.SamePathOrUnder("Error from Logger2: fake Exception"));
        }
    }
}
