using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTernarySearchTree
{
    public class MLSharpPython : IMLSharpPython
    {
        public readonly string filePythonExePath;

        public MLSharpPython(string filePython)
        {
            filePythonExePath = filePython;

        }

        public string ExcutePythonScript(string filePython, out string standardError)
        {
            string outputText = string.Empty;
            standardError = string.Empty;
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo(filePythonExePath)
                    {
                        Arguments = filePython,
                        UseShellExecute = false,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };

                    process.Start();

                    outputText = process.StandardOutput.ReadToEnd();
                    outputText = outputText.Replace(Environment.NewLine, string.Empty);
                    standardError = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                }  
            }
            catch(Exception ex)
            {
                string exceptionError = ex.Message;
            }

            return outputText;
        }
    }
}
