using Chapter2.LogAnalyzer2;
using Chapter2.LogAnalyzer3;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests.LogAnalyzer2Tests
{
    // fake objects combination: 1 - stub, 2 - mock
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        // WITHOUT NSubstitute
        [Test]
        public void Analyze_Logger2Throws_CallsWebService()
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

        // WITH NSubstitute
        [Test]
        public void Analyze_Logger2Throws_CallsWebService_NSub()
        {
            var mockWebService = NSubstitute.Substitute.For<IWebService2>();
            var stubLogger = NSubstitute.Substitute.For<ILogger2>();

            //simulation of exception on any input
            stubLogger
                .When(logger => logger.LogError(Arg.Any<String>()))
                .Do(info => { throw new Exception("fake Exception"); });

            var analyzer = new LogAnalyzer2(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.Received().Write(Arg.Is<String>(s => s.Contains("fake Exception")));
        }

        // full object comparison 
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
        {
            var mockWebService = Substitute.For<IWebService3>();
            var stubLogger = Substitute.For<ILogger3>();
            stubLogger
                .When(logger => logger.LogError(Arg.Any<String>()))
                .Do(info => { throw new Exception("fake Exception"); });

            var analyzer = new LogAnalyzer3(stubLogger, mockWebService);
            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            var expected = new ErrorInfo(1000, "fake Exception");
            mockWebService.Received().Write(expected);
        }
    }
}
