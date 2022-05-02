using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            this._groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Group> groups = await this._groupService.GetAllAsync();

                return Ok(groups);
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
                Group group = await this._groupService.GetByIdAsync(id: id);

                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Group group)
        {
            try
            {
                await this._groupService.PostAsync(group: group);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo crear el jugador.", ex = ex });
            }
        }
    }
}
