using System.Threading.Tasks;

namespace Towing
{
    internal interface IContent
    {
        frmMain MainForm { get; set; }

        Task LoadData();
    }
}
