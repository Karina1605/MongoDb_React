using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbExample.RepositoryInterfaces;
using MongoDbExample.Models;
using MongoDbExample.Filters;

namespace MongoDbExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UsersController : ControllerBase
    {
        private readonly ISocialNetworkDataBase _repo;
        public UsersController(ISocialNetworkDataBase repo)
        {
            _repo = repo;

        }

        public async Task<IActionResult> GetAll()
        {
            string[] attibutes = new string[] { "FirstName", "LastName", "MinAge", "MaxAge" };
            var userFilter = new UserFilter();
            var result = await _repo.Users.GetByAttrubutes(userFilter
                .SetLastName(Request.Query["Lastname"])
                .SetName(Request.Query["FirstName"])
                .SetMinAge(Int32.Parse(Request.Query["MinAge"]))
                .SetMaxAge(Int32.Parse(Request.Query["MaxAge"])).GetObj);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await _repo.Users.Delete(id);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var res = await _repo.Users.Create(user);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var res = await _repo.Users.Update(user);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            var res = await _repo.Users.GetById(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
