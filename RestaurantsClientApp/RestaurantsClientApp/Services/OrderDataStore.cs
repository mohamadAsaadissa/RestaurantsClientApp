using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class OrderDataStoreAsyncRepository : IDataStore<Order>
    {

        private SQLiteAsyncConnection database;
        static object locker = new object();


        public OrderDataStoreAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            // create the table.NO NEED if DO'nT exist in DB
            database.CreateTableAsync<Order>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Order>();
        }
        public async Task<IEnumerable<Order>> GetItemsAsync()
        {
            return await database.Table<Order>().ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetItemsAsync(string id)
        {
            return await database.Table<Order>().Where(x => x.OrderId == id).ToListAsync();
        }

        public async Task<int> DeleteItemAsync(Order item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllItemAsync()
        {
            return await database.Table<Order>().DeleteAsync();
        }
        public async Task<object> SaveItemAsync(Order item)
        {
            
                return await database.InsertAsync(item); //create new
           

        }
        public async Task<object> UpdateItemAsync(Order item)
        {
            if (String.IsNullOrEmpty(item.OrderId))
            {
                await database.UpdateAsync(item);

            }
            return item.OrderId;
        }

        public async Task<Order> GetItemAsync(string id)
        {
            return await database.GetAsync<Order>(id);
        }

       
    }
}