using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cei.Api.Common.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Cei.Api.Common.Services
{
    public class MongoCrudService<ModelType> : ICrudService<ModelType> where ModelType : IMongoModel
    {
        protected IMongoCollection<ModelType> collection { get; }

        public MongoCrudService(ICeiApiDB dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
        }

        public MongoCrudService(ICeiApiDB dbSettings, string collectionName)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            this.collection = database.GetCollection<ModelType>(collectionName);
        }

        public Task<ModelType> GetByIdAsync(string Id) =>
            this.collection
                .Find(m => m.Id == Id)
                .SingleOrDefaultAsync();

        public Task<ResultType> GetByIdAsync<ResultType>(
            string Id, Expression<Func<ModelType, ResultType>> projection) =>
                this.collection
                    .Find(m => m.Id == Id)
                    .Project(projection)
                    .SingleOrDefaultAsync();

        public Task<ModelType> GetFirstAsync(
            Expression<Func<ModelType, bool>> predicate) =>
                this.collection
                    .Find(predicate)
                    .FirstOrDefaultAsync();

        public Task<ResultType> GetFirstAsync<ResultType>(
            Expression<Func<ModelType, bool>> predicate,
            Expression<Func<ModelType, ResultType>> projection) =>
                this.collection
                    .Find(predicate)
                    .Project(projection)
                    .FirstOrDefaultAsync();

        public Task<List<ModelType>> GetAllAsync(
            Expression<Func<ModelType, bool>> predicate) =>
                this.collection
                    .Find(predicate)
                    .ToListAsync();

        public Task<List<ResultType>> GetAllAsync<ResultType>(
            Expression<Func<ModelType, bool>> predicate,
            Expression<Func<ModelType, ResultType>> projection) =>
                this.collection
                    .Find(predicate)
                    .Project(projection)
                    .ToListAsync();

        public Task<List<ModelType>> GetByTextSearch(string search)
        {
            var filter = Builders<ModelType>.Filter.Text(search);
            return this.collection
                .Find(filter)
                .ToListAsync();
        }

        public Task<List<ResultType>> GetByTextSearch<ResultType>(
            string search, Expression<Func<ModelType, ResultType>> projection) =>
                this.collection
                    .Find(Builders<ModelType>.Filter.Text(search))
                    .Project(projection)
                    .ToListAsync();

        public Task CreateAsync(ModelType model) =>
            this.collection
                .InsertOneAsync(model);

        public Task UpdateAsync(string id, ModelType model) =>
            this.collection
                .ReplaceOneAsync(m => m.Id == id, model);

        public Task RemoveAsync(ModelType model) =>
            this.collection
                .DeleteOneAsync(m => m.Id == model.Id);

        public Task RemoveAsync(string id) =>
            this.collection
                .DeleteOneAsync(m => m.Id == id);
    }
}