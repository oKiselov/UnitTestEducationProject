using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer2
{
    public class FakeWebService2 : IWebService2
    {
        public string MessageToWebService; 
        
        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }

    public class FakeLogger2 : ILogger2
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;

        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if(WillThrow!= null)
            {
                throw WillThrow;
            }
        }
    }
}
