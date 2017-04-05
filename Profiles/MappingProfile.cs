using AutoMapper;
using System.Linq;
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
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(
                    dest => dest.Features,
                    opt => opt.MapFrom(
                        so => so.VehicleFeatures.Select(m => m.FeatureId)));

            CreateMap<VehicleDto, Vehicle>()
                .ForMember(
                    dest => dest.VehicleFeatures,
                    opt => opt.MapFrom(
                        so => so.Features.Select(m => new VehicleFeature() {
                            FeatureId = m
                        })));
        }
    }
}
