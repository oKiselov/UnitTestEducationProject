using EmailService;
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
    public class LogAnalyzerExceptionTests
    {
        [Test]
        public void Analyze_WebServiceThrpws_SendsEmail()
        {
            FakeWebServiceException stubWebServiceException = new FakeWebServiceException();
            stubWebServiceException.ToThrow = new Exception("fake exception");

            FakeEmailService mockEmailService = new FakeEmailService();

            LogAnalyzerEmalService logAnalyzerEmalService = new LogAnalyzerEmalService(stubWebServiceException, mockEmailService);

            string tooShortfileName = "abc.ext";
            logAnalyzerEmalService.Analyze(tooShortfileName);

            StringAssert.Contains("someone@gmail.com", mockEmailService.To);
            StringAssert.Contains("can't log", mockEmailService.Subject);
            StringAssert.Contains("fake exception", mockEmailService.Body);
        }
    }
}
