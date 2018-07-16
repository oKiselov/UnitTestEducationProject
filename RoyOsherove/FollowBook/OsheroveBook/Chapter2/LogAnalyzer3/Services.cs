using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer3
{
    public class FakeWebService3 : IWebService3
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }

        public void Write(ErrorInfo message)
        {
            //throw new NotImplementedException();
        }
    }

    public class FakeLogger3 : ILogger3
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }
}
