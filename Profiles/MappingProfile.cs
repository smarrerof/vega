using AutoMapper;
using WebApplicationBasic.Data.Dtos;
using WebApplicationBasic.Data.Models;

namespace WebApplicationBasic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<Make, MakeDto>();
            CreateMap<Model, ModelDto>();
        }
    }
}
