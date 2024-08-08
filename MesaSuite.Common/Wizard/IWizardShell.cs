using System.Windows.Forms;

namespace MesaSuite.Common.Wizard
{
    public interface IWizardShell
    {
        ListView Navigation { get; }
        PictureBox Logo { get; }
        Label Title { get; }
        Button RunButton { get; }
        Button CancelButton { get; }
        Button NextButton { get; }
        Button BackButton { get; }
        Panel Content { get; }
        
        void SetWindowText(string text);
        void ShowLoader();
        void HideLoader();
        void ShowWizard();
        void CloseWizard();
    }
}
