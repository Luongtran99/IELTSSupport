using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTernarySearchTree
{
    public interface IMLSharpPython
    {
        string ExcutePythonScript(string filePython, out string standardError);
    }
}
