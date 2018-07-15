using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.LogAnalyzer2
{
    public interface ILogger2
    {
        void LogError(string message);
    }

    public interface IWebService2
    {
        void Write(string message);
    }
}
