using Xam.Models;

namespace Xam.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
            Quantity = 1;
        }

        public int Quantity
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }
    }
}