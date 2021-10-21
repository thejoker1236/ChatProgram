using Models = Chat.Api.Models;
using Chat.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Chat.Api.Controllers
{

    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersRepository repo;

        public UserController(IRepository<Models.User> repo)
        {
            this.repo = (UsersRepository)repo;
        }

        // GET: api/<BaseController>
        [HttpGet]
        public async Task<IEnumerable<Models.User>> Get() => await repo.Get();

        // GET api/<BaseController>/5
        [HttpGet("{id}")]
        public Models.User Get(int id)
        {
            var curruser = User.FindFirst(ClaimTypes.Name).Value;
            return Get(id);
        }

        // POST api/<BaseController>
        [HttpPost]
        public async Task Post([FromBody] Models.User value) => await repo.Add(value);

        // PUT api/<BaseController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Models.User value) => await repo.Update(value);

        // DELETE api/<BaseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id) => await repo.Remove(id);
    }
}
