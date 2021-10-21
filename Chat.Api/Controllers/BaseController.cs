using Chat.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chat.Api.Controllers
{

    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BaseController<model> : ControllerBase where model : Models.IBaseModel
    {
        private readonly IRepository<model> repo;

        public BaseController(IRepository<model> repo)
        {
            this.repo = repo;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public async Task<IEnumerable<model>> Get() => await repo.Get();

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public model Get(int id) => Get(id);

        // POST api/<BaseController>
        [HttpPost]
        public async Task Post([FromBody] model value) => await repo.Add(value);

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] model value) => await repo.Update(value);

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id) => await repo.Remove(id);
    }
}
