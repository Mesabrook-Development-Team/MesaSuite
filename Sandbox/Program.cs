using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Loader;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebModels.account;
using WebModels.hMailServer.dbo;
using WebModels.netprint;
using WebModels.security;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                PrintJob job = DataObjectFactory.Create<PrintJob>();
                job.PrinterID = 2;
                job.DocumentName = "Test Print Job";
                job.Finalized = true;
                if (!job.Save(transaction))
                {
                    return;
                }

                for(byte i = 1; i <= 2; i++)
                {
                    PrintPage page = DataObjectFactory.Create<PrintPage>();
                    page.PrintJobID = job.PrintJobID;
                    page.DisplayOrder = i;
                    if (!page.Save(transaction))
                    {
                        return;
                    }

                    for(byte j = 2; j > 0; j--)
                    {
                        PrintLine line = DataObjectFactory.Create<PrintLine>();
                        line.PrintPageID = page.PrintPageID;
                        line.Alignment = PrintLine.Alignments.Left;
                        line.Text = $"Page {i} Line {j}";
                        line.DisplayOrder = j;
                        if (!line.Save(transaction))
                        {
                            return;
                        }
                    }
                }

                transaction.Commit();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
