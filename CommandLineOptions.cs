using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace poc_windowsservice_preflightcheck
{
    public class CommandLineOptions
    {
        [Option('p', "preflight")]
        public bool PreflightCheck { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return
                @"Usage:
                poc-windowsservice-preflightcheck.exe [--preflight]
                
                --preflight Starts the application in a pre-flight mode to validate whether application is good to go. 
                            Application will return exit code 0 (success) or 1 (failure).
                
                ";
        }
    }
}
