using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xam.Models;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(Xam.Services.MockDataStore))]
namespace Xam.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        private async Task InitializeAsync()
        {
            //var path = DependencyService.Get<IPlatformInfo>();
            //File.WriteAllText("text.txt", "text");
           // var text = File.ReadAllText("text.txt");

            if (isInitialized)
                return;

            items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some cat food", Description="The cats are hungry"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Learn F#", Description="Seems like a functional idea"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description="Noted"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
            };

            isInitialized = true;

            await Task.FromResult(0);
        }

        public async Task SaveAsync(Item entity)
        {
            await InitializeAsync();

            var item = items.Where((Item arg) => arg.Id == entity.Id).FirstOrDefault();
            if (item != null)
            {
                items.Remove(item);
            }
            items.Add(item);
        }

        public async Task DeleteAsync(Item entity)
        {
            await InitializeAsync();

            var item = items.Where((Item arg) => arg.Id == entity.Id).FirstOrDefault();
            items.Remove(item);
        }

        public async Task<Item> GetAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> QueryAsync()
        {
            await InitializeAsync();
            return items;
        }
    }
}
