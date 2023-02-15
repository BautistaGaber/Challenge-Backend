using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAlkemy.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterServices _service; 
        public CharacterController(ICharacterServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacter()
        {
            return Ok(await _service.GetCharacters());
        }

        [HttpGet]
        [Route("/buscarPersonaje/{id}")]
        public async Task<IActionResult> GetCharacterById([FromRoute]int id)
        {
            return Ok(await _service.GetCharacterById(id));
        }

        [HttpGet]
        [Route("/serchCharacterWithAllProperties/")]
        public async Task<IActionResult> GetCharacterWithAllProperties()
        {
            return Ok(await _service.GetCharactersWithAllProperties());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody]CreateCharacterDTO createcharacterdto)
        {
            var result = _service.CreateCharacter(createcharacterdto);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter([FromBody]UpdateCharacterDTO updateCharacterDto, [FromQuery]int id)
        {           
            var result = _service.UpdateCharacter(updateCharacterDto,id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var result = _service.DeleteCharacter(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}    



