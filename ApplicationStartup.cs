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
            var options = new CommandLineOptions();

            try
            {
                var isValid = CommandLine.Parser.Default.ParseArguments(Environment.GetCommandLineArgs(), options);
                if (isValid && options.PreflightCheck)
                    return StartupMode.Preflight;
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Console.Error.WriteLine(options.GetUsage());
            }

            return StartupMode.Normal;
        }
    }

    public enum StartupMode
    {
        Normal,
        Preflight,
    }
}
