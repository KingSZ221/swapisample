using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.SolidWorks;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var swProcess = Process.GetProcessesByName("SLDWORKS");
            if(!swProcess.Any())
            {
                Console.WriteLine("SolidWorks 没有打开");
                Console.ReadKey();

                var swApp = SwApplicationFactory.Create(Xarial.XCad.SolidWorks.Enums.SwVersion_e.Sw2020);
                swApp.ShowMessageBox("Hello New SolidWorks!");
            }
            else
            {
                var swApp = SwApplicationFactory.FromProcess(swProcess.First());

                var part = swApp.Sw.NewPart() as IPartDoc;

                Console.ReadKey();
            }
        }
    }
}
