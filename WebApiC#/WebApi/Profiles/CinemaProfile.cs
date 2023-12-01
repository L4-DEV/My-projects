using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CinemaProfile:Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<PutCinemaDto, Cinema>();
            CreateMap<Cinema, PatchCinemaDto>();
            CreateMap<PatchCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
               .ForMember(cinemaDto => cinemaDto.Endereco,
                   opt => opt.MapFrom(cinema => cinema.Endereco))
               .ForMember(cinemaDto => cinemaDto.Sessoes,
                   opt => opt.MapFrom(cinema => cinema.Sessoes));

        }
    }
}
