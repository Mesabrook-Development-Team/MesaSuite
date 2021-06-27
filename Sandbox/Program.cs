using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.security;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Permission permission = DataObjectFactory.Create<Permission>();
            //Schema.Deploy();

            LoaderController loader = new LoaderController();
            loader.Initialize();
            loader.Process();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
