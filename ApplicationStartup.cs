using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_windowsservice_preflightcheck
{
    public static class ApplicationStartup
    {
        public static StartupMode GetStartupMode()
        {
            try
            {
                var options = new CommandLineOptions();
                var isValid = CommandLine.Parser.Default.ParseArguments(Environment.GetCommandLineArgs(), options);

                if (isValid && options.Preflight)
                    return StartupMode.RunPreflightCheck;
            }
            catch(Exception e)
            {
                Console.WriteLine("Encountered an exception trying to determine StartupMode [RunNormally, RunPreflightCheck].");
                Console.WriteLine(e.ToString());
            }

            return StartupMode.RunNormally;
        }

    }

    public enum StartupMode
    {
        RunNormally,
        RunPreflightCheck,
    }
}
