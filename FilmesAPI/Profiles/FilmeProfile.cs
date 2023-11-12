using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile() 
        {
            CreateMap<CreateFilmeDtos, Filme>();
            CreateMap<UpdateFilmeDtos, Filme>();
            CreateMap<Filme, UpdateFilmeDtos>();
            CreateMap<Filme, ReadFilmeDtos>();
        }

    }
}
