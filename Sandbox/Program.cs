using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebModels.account;
using WebModels.hMailServer.dbo;
using WebModels.security;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = DataObjectFactory.Create<User>();
            //Schema.Deploy();

            //LoaderController loader = new LoaderController();
            //loader.Initialize();
            //loader.Process();

            DateTime date = DateTime.Now;
            for (int i = 0; i < 220; i++)
            {
                date = date.AddMinutes(-1);
                Transaction transaction = DataObjectFactory.Create<Transaction>();
                transaction.TransactionTime = date;
                transaction.Amount = 0;
                transaction.Description = "Test";
                transaction.FiscalQuarterID = 1;
                transaction.Save();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
