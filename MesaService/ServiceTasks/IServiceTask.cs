using System;
using System.Threading.Tasks;

namespace MesaService.ServiceTasks
{
    internal interface IServiceTask
    {
        string Name { get; }
        bool Run();
        DateTime NextRunTime { get; }
    }
}
