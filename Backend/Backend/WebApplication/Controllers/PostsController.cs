using ClassLibrary.Business;
using ClassLibrary.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetPosts()
        {
            string jsonResult;
            var dt = Posts.GetPostsDataTable();
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
        [HttpPost]
        public ActionResult<Post> AddPost(Post post)
        {
            var u = Posts.AddPost(post);
            return Ok(u);
        }
    }
}
