using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class FakeWebService: IWebService
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }

    public class FakeWebServiceException : IWebService
    {
        public Exception ToThrow;
        public void LogError(string message)
        {
            if(ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }

    public class LogAnalyzerWebService
    {
        private IWebService service;

        public LogAnalyzerWebService(IWebService service)
        {
            this.service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                service.LogError("Filename is too short: " + fileName);
            }
        }
    }
}
