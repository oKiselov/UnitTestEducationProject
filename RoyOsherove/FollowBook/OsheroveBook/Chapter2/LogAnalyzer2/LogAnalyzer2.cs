using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer2
{
    // class under test
    public class LogAnalyzer2
    {
        private ILogger2 logger;
        private IWebService2 webService;

        public LogAnalyzer2(ILogger2 logger, IWebService2 webService)
        {
            this.logger = logger;
            this.webService = webService;
        }

        public int MinNameLength { get; set; }
        
        public void Analyze(string fileName)
        {
            if(fileName.Length < MinNameLength)
            {
                try
                {
                    logger.LogError(string.Format("FileName is too short: {0}", fileName));
                }
                catch (Exception e)
                {
                    webService.Write("Error from Logger2: " + e.Message);
                }
            }
            
        }
    }
}
