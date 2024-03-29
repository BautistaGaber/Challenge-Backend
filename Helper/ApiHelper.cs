﻿using ChallengeAlkemy.Core.User;
using ChallengeAlkemy.Core.Users;
using ChallengeAlkemy.DTO.DTOs;
using ChallengeAlkemy.DTO.MoviesDTO;
using ChallengeAlkemy.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChallengeAlkemy.Helper
{
    public class ApiHelper
    {
        public static Movie CreateMovieDtoToEntity(CreateMovieDTO dto)
        {
            Movie movie = new Movie();
            movie.Image = dto.Image;
            movie.Title = dto.Title;
            movie.Qualification = dto.Qualification;
            movie.Creation = DateTime.Now;
            movie.GenderId = dto.GenderId;  

            return movie;
        }

        public static Character CreateCharacterToEntity(CreateCharacterDTO dto)
        {
            Character character = new Character();
            character.Image = dto.Image;
            character.Weight = dto.Weight;
            character.Name = dto.Name;
            character.Age = dto.Age;
            character.History = dto.History;

            return character;
        }

        public static User CreateUserToEntity(UserDTO dto)
        {
            User user = new User();
            user.Username = dto.UserName;
            user.Password = dto.Password;

            return user;
        }
         
        public static Character UpdateCharacterToEntity(UpdateCharacterDTO dto, Character character)
        {
            character.Age = dto.Age;
            character.Weight = dto.Weight;
            character.Name = dto.Name;
            character.History = dto.History;
            character.Image = dto.Image;

            return character;
        }

        public static Movie UpdateMovieToEntity(UpdateMovieDTO dto, Movie movie)
        {
            movie.GenderId = dto.GenderId;
            movie.Title = dto.Title;
            movie.Qualification = dto.Qualification;
            movie.Image = dto.Image;

            return movie;
        }

    }
}
