using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Post> posts = await this._postService.GetAllAsync();

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByGroupId(string groupId)
        {
            try
            {
                List<Post> posts = await this._postService.GetByGroupIdAsync(groupId: groupId);

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Post post = await this._postService.GetByIdAsync(id: id);

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            try
            {
                await this._postService.PostAsync(post: post);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo crear el jugador.", ex = ex });
            }
        }
    }
}
