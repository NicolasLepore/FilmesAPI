using AutoMapper;
using FilmesAPI.Data.Dtos.CinemaDtos;
using FilmesAPI.Models;

#pragma warning disable 1591

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco, // EnderecoDto
                    opt => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(cinemaDto => cinemaDto.Sessoes,
                    opt => opt.MapFrom(cinema => cinema.Sessoes));
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
 