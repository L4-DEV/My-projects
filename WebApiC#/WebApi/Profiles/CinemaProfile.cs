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
            CreateMap<Cinema, ReadCinemaDto>();
        }
    }
}
