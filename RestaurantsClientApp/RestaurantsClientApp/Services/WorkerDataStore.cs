using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class WorkerAsyncRepository : IDataStore<Worker>
    {

        private SQLiteAsyncConnection database ;

        static object locker = new object();

        public WorkerAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            // create the table if no exist in DB
            database.CreateTableAsync<Worker>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Worker>();
        }
        public async Task<IEnumerable<Worker>> GetItemsAsync()
        {
            return await database.Table<Worker>().ToListAsync();
        }

        public async Task<Worker> GetItemAsync(string id)
        {
            return await database.GetAsync<Worker>(id);
        }

        public async Task<int> DeleteItemAsync(Worker item)
        {
            return await database.DeleteAsync(item);
        }

        public async Task<object> SaveItemAsync(Worker item)
        {
            
          return await database.InsertAsync(item);
           
        }
        public async Task<object> UpdateItemAsync(Worker item)
        {
            if (String.IsNullOrEmpty(item.WorkerId))
            {
                await database.UpdateAsync(item);
               
            }
            return item.WorkerId;
        }

        public Task<IEnumerable<Worker>> GetItemsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}