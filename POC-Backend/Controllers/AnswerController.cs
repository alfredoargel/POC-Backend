using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Backend.Application.Entities;
using POC_Backend.Application.Interfaces;

namespace POC_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            this._answerService = answerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Answer> answers = await this._answerService.GetAllAsync();

                return Ok(answers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByPostId(string postId)
        {
            try
            {
                List<Answer> answers = await this._answerService.GetByPostIdAsync(postId: postId);

                return Ok(answers);
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
                Answer answer = await this._answerService.GetByIdAsync(id: id);

                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al consultar los jugadores.", ex = ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Answer answer)
        {
            try
            {
                await this._answerService.PostAsync(answer: answer);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "No se pudo crear el jugador.", ex = ex });
            }
        }
    }
}
