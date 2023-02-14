using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAlkemy.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _service;

        public GenderController(IGenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGender()
        {
            return Ok(await _service.GetGender());
        }
    }
}
