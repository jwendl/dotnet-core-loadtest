using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCore.Interfaces
{
    public interface IDataRepository<TKey, TModel>
    {
        Task InitializeDatabaseAsync(string partitionKeyPath, string databaseId, string collectionId);

        Task<TModel> FetchItemAsync(TKey partitionKey, string id);

        Task<IEnumerable<TModel>> FetchItemsAsync(TKey partitionKey);

        Task<IEnumerable<TModel>> FindItemsAsync(TKey partitionKey, Expression<Func<TModel, bool>> predicate);

        Task<TModel> CreateItemAsync(TKey partitionKey, TModel item);

        Task<TModel> CreateItemIfNotExistsAsync(TKey partitionKey, TModel item);

        Task<TModel> UpdateItemAsync(TKey partitionKey, string id, TModel item);

        Task DeleteItemAsync(TKey partitionKey, string id);
    }
}
