using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2.FileNameRules
{
    public interface IFileNameRules
    {
        bool IsValideLogFileName(string fileName);
    }
}
