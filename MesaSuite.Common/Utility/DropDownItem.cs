namespace MesaSuite.Common.Utility
{
    public class DropDownItem<T>
    {
        public T Object { get; set; }
        public string Text { get; set; }

        public DropDownItem(T backingObject, string text)
        {
            Object = backingObject;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }

    public class DropDownItem
    {
        public static DropDownItem<T> Create<T>(T backingObject, string text)
        {
            return new DropDownItem<T>(backingObject, text);
        }
    }
}
