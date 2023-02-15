using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Helper;
using ChallengeAlkemy.Models;
using System.IO.Pipelines;

namespace ChallengeAlkemy.Core.Services
{
    public class CharacterService : ICharacterServices
    {

        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository reporitory)
        {
            _repository = reporitory;
        }

        public Task CharaterMovie(int id, List<int> characterid)
        {
            throw new NotImplementedException();
        }

        public async Task<Character> CreateCharacter(CreateCharacterDTO createcharacterdto)
        {
             return await _repository.CreateCharacter(ApiHelper.CreateCharacterToEntity(createcharacterdto));             
        }

        public async Task DeleteCharacter(int id)
        {
            await _repository.DeleteCharacter(id);
        }

        public async Task<Character> GetCharacterById(int id)
        {
            return await _repository.GetCharacterById(id);
        }

        public async Task<List<ViewCharacterDTO>> GetCharacters()
        {
            List<ViewCharacterDTO> list = new List<ViewCharacterDTO>();
            List<Character> characterList = await _repository.GetCharacters();
            characterList.ForEach(c => list.Add(new ViewCharacterDTO(c)));
            return list;
        }

        public async Task<List<FullCharacterDTO>> GetCharactersWithAllProperties()
        {
            List<FullCharacterDTO> list = new List<FullCharacterDTO>();
            List<Character> characterList = await _repository.GetCharacters();
            characterList.ForEach(c => list.Add(new FullCharacterDTO(c)));
            return list;
        }

        public async Task UpdateCharacter(UpdateCharacterDTO upgradeCharacterDto, int id)
        {

            Character character = await _repository.GetCharacterById(id);
            if (character == null)
                return;
            await _repository.UpdateCharacter(ApiHelper.UpdateCharacterToEntity(upgradeCharacterDto,character)); 
        }

    }
}
