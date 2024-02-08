using asset_mate_api.Dtos;
using asset_mate_core.Entities;
using AutoMapper;

namespace asset_mate_api.Helpers
{
    public class VehicleUrlResolver : IValueResolver<Vehicle, VehicleToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public VehicleUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Vehicle source, VehicleToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}