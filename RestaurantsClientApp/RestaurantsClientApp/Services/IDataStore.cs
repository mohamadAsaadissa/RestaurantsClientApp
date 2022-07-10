using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantsClientApp.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(string id);
        Task<int> DeleteItemAsync(T item);
        Task<object> SaveItemAsync(T item);
        Task<object> UpdateItemAsync(T item);
        Task CreateTable();
    }
   
}
