using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer3
{
    public interface IWebService3
    {
        void Write(string message);
        void Write(ErrorInfo message);
    }

    public interface ILogger3
    {
        void LogError(string message);
    }
}
