using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class DetailOrderDataStoreAsyncRepository : IDataStore<DetailOrder>
    {

        private SQLiteAsyncConnection database;
        static object locker = new object();


        public DetailOrderDataStoreAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            // create the table.NO NEED if DO'nT exist in DB
            database.CreateTableAsync<DetailOrder>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<DetailOrder>();
        }
        public async Task<IEnumerable<DetailOrder>> GetItemsAsync()
        {
            return await database.Table<DetailOrder>().ToListAsync();
        }

        public async Task<IEnumerable<DetailOrder>> GetItemsAsync(string id)
        {
            return await database.Table<DetailOrder>().Where(x => x.OrderId == id).ToListAsync();
        }

        public async Task<int> DeleteItemAsync(DetailOrder item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllItemAsync()
        {
            return await database.Table<DetailOrder>().DeleteAsync();
        }
        public async Task<object> SaveItemAsync(DetailOrder item)
        {
            
                return await database.InsertAsync(item); //create new
           

        }
        public async Task<object> UpdateItemAsync(DetailOrder item)
        {
            if (String.IsNullOrEmpty(item.OrderId))
            {
                await database.UpdateAsync(item);

            }
            return item.OrderId;
        }

        public async Task<DetailOrder> GetItemAsync(string id)
        {
            return await database.GetAsync<DetailOrder>(id);
        }

       
    }
}