using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_windowsservice_preflightcheck
{
    public class MyService
    {
        public void Stop()
        {
            Console.WriteLine("Service is exiting.");
        }

        public void PreFlightCheck()
        {
            Console.WriteLine("Running a preflight check...");

            var canBeZeroOrOne = new Random().Next(2);

            if (canBeZeroOrOne == 0)
            {
                Console.WriteLine("Pre-flight check successful. Process is ready to run!");
                Console.WriteLine("Returning exit code 0.");
            }
            else
            {
                Console.Error.WriteLine("Pre-flight check failed.");
                Console.Error.WriteLine("Returning exit code 1.");
            }

            Console.WriteLine("Type the following command on your Powershell terminal to find the exit code of the most recently exited process:");
            Console.WriteLine("echo $LastExitCode");

            Environment.Exit(canBeZeroOrOne);
        }

        public void Start()
        {
            Console.WriteLine("Pre-flight mode wasn't specified. Running normally.");
        }
    }
}
