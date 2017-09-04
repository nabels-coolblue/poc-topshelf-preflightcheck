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
        static bool _preflight = false;

        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyService>(s =>
                {
                    s.WhenStarted(service => service.Start(_preflight));
                    s.WhenStopped(service => service.Stop());
                    s.ConstructUsing(() => new MyService());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Service that has a pre-flight check. Run with --preflight argument to test.");
                x.SetDisplayName("My TopShelf service");
                x.SetServiceName("MyTopShelfService");

                x.AddCommandLineSwitch("preflight", preflight => _preflight = preflight);
            });
        }
    }
}
