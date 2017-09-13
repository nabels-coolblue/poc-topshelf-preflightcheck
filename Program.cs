using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Topshelf;

namespace poc_windowsservice_preflightcheck
{
    class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyService>(s =>
                {
                    if (ApplicationStartup.GetStartupMode() == StartupMode.Preflight)
                        s.WhenStarted(service => service.PreFlightCheck());
                    else
                        s.WhenStarted(service => service.Start());
                    
                    s.WhenStopped(service => service.Stop());
                    s.ConstructUsing(() => new MyService());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Service that has a pre-flight check. Run with --preflight argument to test.");
                x.SetDisplayName("My TopShelf service");
                x.SetServiceName("MyTopShelfService");

                // TopShelf requires the --preflight command-line switch to be whitelisted
                x.AddCommandLineSwitch("preflight", ignore => ignore.ToString());
            });
        }
    }
}
