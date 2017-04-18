namespace Xam.Models
{
    public class Item : BaseDataObject
    {
        public Item()
        {
            Text = string.Empty;
            Description = string.Empty;
        }

        public string Text
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
    }
}
