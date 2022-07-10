using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class ClientAsyncRepository : IDataStore<Client>
    {

       private SQLiteAsyncConnection database ;
        static object locker = new object();

        public ClientAsyncRepository(string databasePath)
        {         
            database = new SQLiteAsyncConnection(databasePath);
            //create the table if no exist in DB
           
            database.CreateTableAsync<Client>();
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Client>();
        }
        public async Task<IEnumerable<Client>> GetItemsAsync()
        {
            return await database.Table<Client>().ToListAsync();
        }

        public async Task<Client> GetItemAsync(string id)
        {
            return await database.GetAsync<Client>(id);
        }

        public async Task<int> DeleteItemAsync(Client item)
        {
            return await database.DeleteAsync(item);
        }

        public async Task<object> SaveItemAsync(Client item)
        {         
            
           return await database.InsertAsync(item);
          
        }
        public async Task<object> UpdateItemAsync(Client item)
        {
            if (!String.IsNullOrEmpty(item.ClientId))
            {
                await database.UpdateAsync(item);
               
            }
            return item.ClientId;
        }

        public Task<IEnumerable<Client>> GetItemsAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}