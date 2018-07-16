using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer3
{
    public class LogAnalyzer3
    {
        private ILogger3 _logger;
        private IWebService3 _webService;


        public LogAnalyzer3(ILogger3 logger, IWebService3 webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError(string.Format("Filename too short: {0}", filename));
                }
                catch (Exception e)
                {
                    _webService.Write(new ErrorInfo(1000, e.Message));

                }
            }
        }
    }

}
