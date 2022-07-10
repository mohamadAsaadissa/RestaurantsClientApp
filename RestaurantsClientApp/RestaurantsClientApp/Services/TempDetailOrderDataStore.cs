using RestaurantsClientApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public class TempDetailOrderDataStoreAsyncRepository : IDataStore<TempDetailOrder>
    {

        private SQLiteAsyncConnection database;
        static object locker = new object();


        public TempDetailOrderDataStoreAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            // create the table.NO NEED if DO'nT exist in DB
            database.CreateTableAsync<TempDetailOrder>();
        }
        public async Task CreateTable()
        {
            await database.CreateTableAsync<TempDetailOrder>();
        }
        public async Task<IEnumerable<TempDetailOrder>> GetItemsAsync()
        {
            return await database.Table<TempDetailOrder>().ToListAsync();
        }

        public async Task<IEnumerable<TempDetailOrder>> GetItemsAsync(string id)
        {
            return await database.Table<TempDetailOrder>().Where(x => x.TempMealId == id).ToListAsync();
        }

        public async Task<int> DeleteItemAsync(TempDetailOrder item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> DeleteAllItemAsync()
        {
            return await database.Table<TempDetailOrder>().DeleteAsync();
        }
        public async Task<object> SaveItemAsync(TempDetailOrder item)
        {
            // IF meal existed in database
            var order = await database.Table<TempDetailOrder>().Where(x => x.TempMealId == item.TempMealId).FirstOrDefaultAsync();

            //
            if (order == null)

                return await database.InsertAsync(item); //create new
            else
            {
                order.TempQuantity = item.TempQuantity;
                order.TempSumma = item.TempSumma;
                return await database.UpdateAsync(order);// update quantity in order
                                                        
             }

        }
        public async Task<object> UpdateItemAsync(TempDetailOrder item)
        {
            if (!String.IsNullOrEmpty(item.TempMealId))
            {
                await database.UpdateAsync(item);

            }
            return item.TempMealId;
        }

        public async Task<TempDetailOrder> GetItemAsync(string id)
        {
            return await database.GetAsync<TempDetailOrder>(id);
        }

        public async Task <(double, double, double)> GetOrderTotalAsync()
        {

            double summ = 0;
            var items = await GetItemsAsync();

            foreach (TempDetailOrder order in items)
            {
                summ += order.TempSumma;

            }
            double moms = 0.25 * summ;
            double total = summ + moms;

            return (summ, moms, total);
        }
    }
}