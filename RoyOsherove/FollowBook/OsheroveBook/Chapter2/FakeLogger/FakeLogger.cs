using LogAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeLogger
{
    public interface ILogger
    {
        void LogError(string message);
    }

    public class FakeLogger : ILogger, IExtensionManager
    {
        public string LastError;

        public bool IsValid(string fileName)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
