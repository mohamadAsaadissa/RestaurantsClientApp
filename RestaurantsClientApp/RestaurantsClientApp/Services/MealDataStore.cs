using RestaurantsClientApp.Models;
using RestaurantsClientApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class MealAsyncRepository : IDataStore<Meal>
    {

        private SQLiteAsyncConnection database ;
        static object locker = new object();
     

        public MealAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
           // create the table.NO NEED if DO'nT exist in DB
            database.CreateTableAsync<Meal>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Meal>();
        }
        public async Task<IEnumerable<Meal>> GetItemsAsync()
        {
            return await database.Table<Meal>().ToListAsync();
        }

        public async Task<IEnumerable<Meal>> GetItemsAsync(string id)
        {
            return await database.Table<Meal>().Where(x=>x.MenuId == id).ToListAsync();
        }

        public async Task<int> DeleteItemAsync(Meal item)
        {
            return await database.DeleteAsync(item);
        }

        public async Task<object> SaveItemAsync(Meal item)
        {
           
                return await database.InsertAsync(item);
            
        }
        public async Task<object> UpdateItemAsync(Meal item)
        {
            if (String.IsNullOrEmpty(item.MenuId))
            {
                await database.UpdateAsync(item);
                
            }
            return item.MenuId;
        }

        public async Task<Meal> GetItemAsync(string id)
        {
            return await database.GetAsync<Meal>(id);
        }
    }
}