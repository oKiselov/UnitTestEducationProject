using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer(IExtensionManager manager)
        {
            this.manager = manager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName);
        }
    }

    //public class FileExtensionManager : IExtensionManager
    //{
    //    public bool IsValid(string fileName)
    //    {
    //        if (string.IsNullOrEmpty(fileName))
    //        {
    //            throw new ArgumentException("filename has to be provided");
    //        }
    //        if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //}

    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }

    public class AlwaysValidFakeExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
}
