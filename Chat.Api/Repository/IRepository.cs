using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Api.Repository
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> Get();

        public Task<T> Get(string id);

        public Task<T> Add(T item);

        public Task Remove(string id);

        public Task Update(T item);

    }
}