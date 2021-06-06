using Microsoft.Extensions.Logging;
using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Infrastructure.Parser
{
    public class GrammarChecker : IGrammarChecker
    {
        public ILogger<GrammarChecker> _logger;

        private string pythonExecutionFile = @"c:\program files (x86)\microsoft visual studio\shared\python36_64\python.exe";

        private string pythonScriptFile = Path.Combine(Environment.CurrentDirectory, "Python", "grammar_checker.py");

        private readonly ProcessStartInfo _psi = new ProcessStartInfo();

        public List<EssayErrors> _errors { get; set; }

        public GrammarChecker(ILogger<GrammarChecker> logger)
        {
            //_psi.FileName = pythonExecutionFile;
            _errors = new List<EssayErrors>();
            _logger = logger;
            // config psi
            configPsi();
        }

        public void configPsi()
        {
            _psi.FileName = pythonExecutionFile;
            _psi.UseShellExecute = false;
            _psi.CreateNoWindow = true;
            _psi.RedirectStandardOutput = true;
            _psi.RedirectStandardError = true;
        }

        // check sentence
        public async Task<List<EssayErrors>> CheckSentenceAsync(string sentence)
        {


            _psi.Arguments = $"\"{pythonScriptFile}\" \"{sentence}\"";

            try
            {
                var errors = "";
                var result = "";

                
                using (var process = Process.Start(_psi)) 
                {
                    errors = process.StandardError.ReadToEnd();
                    result = process.StandardOutput.ReadToEnd();

                    process.Dispose();

                }
                
                

                string[] rowResultList = result.Split(new char[] { '\n' });

                int numRowResult = Convert.ToInt32(rowResultList[0]);

                if(numRowResult == 0)
                {
                    EssayErrors err = new EssayErrors();

                    err.Message = "No Error";

                    _errors.Add(err);

                    return null;
                }
                else
                {
                    //List<EssayErrors> errs = new List<EssayErrors>();

                    

                    for(int i = 1; i <= numRowResult; i++)
                    {
                        EssayErrors essayErrors = new EssayErrors(rowResultList[i]);

                        _errors.Add(essayErrors);

                    }

                    return _errors;

                }

            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }

            return null;

        }

        // improve sentence support



        public void correctGrammar(string sentence)
        {
            // work later

        }


    }
}
