using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerWebServiceTest
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            FakeWebService mockService = new FakeWebService();
            LogAnalyzerWebService logAnalyzerWebService = new LogAnalyzerWebService(mockService);
            string tooShortFileName = "abc.ext";
            logAnalyzerWebService.Analyze(tooShortFileName);

            StringAssert.Contains("Filename is too short: " + tooShortFileName, mockService.LastError);
        }
    }
}
