using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Filters;
using MongoDbExample.Models;
using MongoDbExample.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ISocialNetworkDataBase _repo;
        public PostsController(ISocialNetworkDataBase repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAll()
        {
            string[] attibutes = new string[] { "FirstName", "LastName", "MinAge", "MaxAge" };
            var userFilter = new PostFilter();
            var result = await _repo.Users.GetByAttrubutes(userFilter
                .SetAuthors(Request.Query["Authors"])
                .SetEarliest(DateTime.Parse(Request.Query["Earliestdate"]))
                .GetObj);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var res = await _repo.Posts.Delete(id);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tweet post)
        {
            var res = await _repo.Posts.Create(post);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Tweet post)
        {
            var res = await _repo.Posts.Update(post);
            if (res)
                return Ok();
            return Problem("There are someproblems while connecting the database");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var res = await _repo.Posts.GetById(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
