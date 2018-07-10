using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService;

namespace EmailService
{
    public class FakeEmailService : IEmailService
    {
        public string To;
        public string Subject;
        public string Body;

        public void SendEmail(string to, string subject, string body)
        {
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }
    }

    public class LogAnalyzerEmalService
    {
        public IWebService WebService { get; set; }
        public IEmailService EmailService { get; set; }

        public LogAnalyzerEmalService(IWebService webService, IEmailService emailService)
        {
            this.WebService = webService;
            this.EmailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if(fileName.Length < 8)
            {
                try
                {
                    WebService.LogError("Filename is too short: " + fileName);
                }
                catch (Exception ex)
                {
                    EmailService.SendEmail("someone@gmail.com", "can't log", ex.Message);
                }
            }
        }
    }
}
