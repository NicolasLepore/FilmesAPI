using AutoMapper;
using FilmesAPI.Data.Dtos.FilmesDtos;
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
            CreateMap<Filme, ReadFilmeDtos>()
                .ForMember(filmeDto => filmeDto.Sessoes,
                    opt => opt.MapFrom(filme => filme.Sessoes));
        }

    }
}
