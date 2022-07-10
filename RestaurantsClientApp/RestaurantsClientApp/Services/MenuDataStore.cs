using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class MenuAsyncRepository : IDataStore<GMenu>
    {

        private SQLiteAsyncConnection database ;
        static object locker = new object();

        public MenuAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            // create the table if no exist in DB
           database.CreateTableAsync<GMenu>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<GMenu>();
        }
        public async Task<IEnumerable<GMenu>> GetItemsAsync()
        {
           
          return await database.Table<GMenu>().ToListAsync();
                     
        }

        public async Task<GMenu> GetItemAsync(string id)
        {
            return await database.GetAsync<GMenu>(id);
        }

        public async Task<int> DeleteItemAsync(GMenu item)
        {
            return await database.DeleteAsync(item);
        }

        public async Task<object> SaveItemAsync(GMenu item)
        {
           
                return await database.InsertAsync(item);
          
        }
        public async Task<object> UpdateItemAsync(GMenu item)
        {
            if (String.IsNullOrEmpty(item.GMenuId))
            {
                await database.UpdateAsync(item);
               
            }
             return item.GMenuId;
        }

        public Task<IEnumerable<GMenu>> GetItemsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}