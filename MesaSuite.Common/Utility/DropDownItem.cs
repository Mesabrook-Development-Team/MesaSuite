using System.Drawing;

namespace MesaSuite.Common.Utility
{
    public class DropDownItem<T> : DropDownItem
    {
        public T Object { get; set; }
        public Color? BackgroundColor { get; set; } = null;
        public Color? FontColor { get; set; } = null;
        public FontStyle? FontStyle { get; set; } = null;

        public DropDownItem(T backingObject, string text)
        {
            Object = backingObject;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

        public DropDownItem<T> CreateCopy()
        {
            return new DropDownItem<T>(Object, Text)
            {
                BackgroundColor = BackgroundColor,
                FontColor = FontColor,
                FontStyle = FontStyle
            };
        }
    }

    public class DropDownItem
    {
        public string Text { get; set; }
        public static DropDownItem<T> Create<T>(T backingObject, string text)
        {
            return new DropDownItem<T>(backingObject, text);
        }
    }
}
