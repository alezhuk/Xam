using Xam.Helpers;
using Xam.Models;
using Xam.Services;

using Xamarin.Forms;

namespace Xam.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            Title = string.Empty;
        }

        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public bool IsBusy
        {
            get { return GetProperty<bool>(); }
            set { SetProperty(value); }
        }

        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }
    }
}

