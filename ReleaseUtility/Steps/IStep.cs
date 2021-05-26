using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    internal interface IStep
    {
        string FriendlyName { get; }
        string DisplayName { get; set; }

        ValidationResult Validate();
        void Execute();

        void ReadXML(XElement element);
        void WriteXML(XElement element);
    }
}
