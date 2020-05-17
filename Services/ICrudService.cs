using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Cei.Api.Common.Services
{
    public interface ICrudService<ModelType>
    {
        Task<ModelType> GetByIdAsync(string Id);

        Task<ResultType> GetByIdAsync<ResultType>(
            string Id, Expression<Func<ModelType, ResultType>> projection);

        Task<ModelType> GetFirstAsync(
            Expression<Func<ModelType, bool>> predicate);

        Task<ResultType> GetFirstAsync<ResultType>(
            Expression<Func<ModelType, bool>> predicate,
            Expression<Func<ModelType, ResultType>> projection);

        Task<List<ModelType>> GetAllAsync(
            Expression<Func<ModelType, bool>> predicate);

        Task<List<ResultType>> GetAllAsync<ResultType>(
            Expression<Func<ModelType, bool>> predicate,
            Expression<Func<ModelType, ResultType>> projection);

        Task<List<ModelType>> GetByTextSearch(string search);

        Task<List<ResultType>> GetByTextSearch<ResultType>(
            string search, Expression<Func<ModelType, ResultType>> projection);

        Task CreateAsync(ModelType model);
        Task<ModelType> UpdateAsync(string id, ModelType model);
        Task<ModelType> DeleteAsync(ModelType model);
        Task<ModelType> DeleteAsync(string id);
    }
}