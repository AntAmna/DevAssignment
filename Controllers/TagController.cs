using System.Collections.Generic;
using DevAssignment.Data;
using DevAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevAssignment.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITag _repository;

        public TagController( ITag repository)
        {
            _repository = repository;

        }

        //GET /api/tags
        [HttpGet]
        public ActionResult<IEnumerable<Tag>> GetBlogPosts()
        {
            var tags = _repository.GetTags();
            return Ok(tags);
        }
    }
}
