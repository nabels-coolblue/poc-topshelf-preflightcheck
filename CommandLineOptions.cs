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
        [Option(HelpText = "Starts the application in a pre-flight mode to validate whether application is good to go.")]
        public bool Preflight { get; set; }
    }
}
