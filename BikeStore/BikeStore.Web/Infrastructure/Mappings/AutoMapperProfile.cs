namespace BikeStore.Web.Infrastructure.Mappings
{
    using AutoMapper;
    using BikeStore.Common.Enums.Bike;
    using BikeStore.Data.Models;
    using BikeStore.Services.Models.Bike;
    using BikeStore.Web.Models.Bikes;
    using System;
    using System.Linq;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<BikeAdCreateModel, BikeAdCreateServiceModel>();
            this.CreateMap<BikeAdUpdateModel, BikeAdUpdateServiceModel>();

            this.CreateMap<BikeAdCreateServiceModel, BikeAd>()
                .ForMember(bike => bike.Type, (IMemberConfigurationExpression<Services.Models.Bike.BikeAdCreateServiceModel, BikeAd, BikeType> cfg) => cfg.MapFrom(bikeServiceModel => (BikeType)bikeServiceModel.Types.Cast<int>().Sum()));

            this.CreateMap<BikeAd, BikeAdServiceModelExtended>()
                .ForMember(bikeServiceModelExtended => bikeServiceModelExtended.Types, cfg => cfg.MapFrom(bike => Enum.GetValues(bike.Type.GetType()).Cast<Enum>().Where(bike.Type.HasFlag)))
                .ForMember(bikeServiceModelExtended => bikeServiceModelExtended.SellerUsername, cfg => cfg.MapFrom(bike => bike.Seller.UserName));

            this.CreateMap<BikeAdServiceModelExtended, BikeAdShortViewModel>();

            this.CreateMap<BikeAdServiceModelExtended, BikeAdDetailedViewModel>();

            this.CreateMap<BikeAdServiceModelExtended, BikeAdUpdateModel>();
        }
    }
}
