using Chat.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Api.Repository
{
    public class UsersRepository : IRepository<User>
    {
        public UsersRepository(IMongoDatabase mongoDatabase)
        {
            this._mongoDatabase = mongoDatabase;
            _collection = mongoDatabase.GetCollection<User>("Users");
        }

        public virtual async Task<User> Add(User item)
        {
            if (_collection.Find(user => user.UserName == item.UserName).Any())
                throw new Exception("User Exists can't add duplicates user"); //todo: exception handling

            await _collection.InsertOneAsync(item);
            return item;
        }

        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly IMongoCollection<User> _collection;


        public async Task<User> Get(string id) => await _collection.Find(item => item.Id.ToString() == id).FirstAsync();


        public async Task<User> GetByUserName(string userName) => await _collection.Find(item => item.UserName == userName).FirstAsync();

        public async Task<IEnumerable<User>> Get() => await _collection.Find(item => true).ToListAsync();

        public async Task Remove(string id) => await _collection.DeleteOneAsync(item => item.ToString() == id);

        public async Task Update(User item) => await _collection.ReplaceOneAsync(book => book.Id == item.Id, item);
    }
}
