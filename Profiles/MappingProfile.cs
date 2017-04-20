using AutoMapper;
using System.Linq;
using vega.Data.Dtos;
using vega.Data.Models;

namespace vega.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTOs
            CreateMap<Feature, FeatureDto>();
            CreateMap<Make, MakeDto>()
                .ForMember(dest => dest.Models, opt => opt.Ignore());
            CreateMap<Model, ModelDto>();
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(
                    dest => dest.Features,
                    opt => opt.MapFrom(
                        so => so.Features.Select(m => m.FeatureId)));

            // DTOs to Domain
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Make, opt => opt.Ignore())
                .ForMember(dest => dest.Model, opt => opt.Ignore())
                .ForMember(dest => dest.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    // Remove unselected features
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                    foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                    // Add new features
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id }).ToList();
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                });
        }
    }
}
