using Chat.Api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Api.Repository
{
    public abstract class BaseRepository<Model> : IRepository<Model> where Model : IBaseModel
    {
        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly IMongoCollection<Model> _collection;

        public BaseRepository(IMongoDatabase mongoDatabase)
        {
            this._mongoDatabase = mongoDatabase;
            _collection = mongoDatabase.GetCollection<Model>(typeof(Model).Name);
        }

        public virtual async Task<Model> Add(Model item)
        {
            await _collection.InsertOneAsync(item);
            return item;
        }

        public virtual async Task<Model> Get(string id) => await _collection.Find(item => item.Id == id).FirstAsync();

        public virtual async Task<IEnumerable<Model>> Get() => await _collection.Find(item => true).ToListAsync();

        public virtual async Task Remove(string id) => await _collection.DeleteOneAsync(item => item.Id == id);

        public virtual async Task Update(Model item) => await _collection.ReplaceOneAsync(book => book.Id == item.Id, item);
    }
}