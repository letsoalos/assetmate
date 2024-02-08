using asset_mate_api.Dtos;
using asset_mate_core.Entities;
using AutoMapper;

namespace asset_mate_api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Vehicle, VehicleToReturnDto>()
                .ForMember(d => d.AssignedDriver, o => o.MapFrom(s => s.AssignedDriver.DriversFullName))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
                .ForMember(d => d.OwnershipCategory, o => o.MapFrom(s => s.OwnershipCategory.Name))
                .ForMember(d => d.VehicleStatus, o => o.MapFrom(s => s.VehicleStatus.Name))
                .ForMember(d => d.FleetType, o => o.MapFrom(s => s.FleetType.Name))
                .ForMember(d => d.VehicleType, o => o.MapFrom(s => s.VehicleType.Name))
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project.ProjectName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<VehicleUrlResolver>());

            CreateMap<AssignedDriver, AssignedDriverToReturnDto>()
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project.ProjectName));

            CreateMap<Branch, BranchToReturnDto>();
        }
    }
}