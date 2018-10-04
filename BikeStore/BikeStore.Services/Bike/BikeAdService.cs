namespace BikeStore.Services.Bike
{
    using BikeStore.Data.Repository.Contracts;
    using BikeStore.Services.Bike.Contracts;
    using BikeStore.Services.Models.Bike;
    using BikeStore.Data.Models;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using BikeStore.Common.Enums.Bike;

    public class BikeAdService : IBikeAdService
    {
        private readonly IDbRepository<BikeAd> bikeRepository;
        private readonly IMapper mapper;

        public BikeAdService(IDbRepository<BikeAd> bikeRepository, IMapper mapper)
        {
            this.bikeRepository = bikeRepository;
            this.mapper = mapper;
        }

        public void Create(BikeAdCreateServiceModel bike)
        {
            var bikeToCreate = this.mapper.Map<BikeAd>(bike);

            this.bikeRepository.Add(bikeToCreate);
            this.bikeRepository.Save();
        }

        public IEnumerable<BikeAdServiceModelExtended> GetAllBikes()
        {
            var allBikes = this.bikeRepository
                .All(bike => bike.Seller)
                .Select(bike => this.mapper.Map<BikeAdServiceModelExtended>(bike))
                .ToList();

            return allBikes;
        }

        public IEnumerable<BikeAdServiceModelExtended> GetAllUserBikes(string userId)
        {
            var allUserBikes = this.bikeRepository
                .All(bike => bike.Seller)
                .Where(bike => bike.SellerId.Equals(userId))
                .Select(bike => this.mapper.Map<BikeAdServiceModelExtended>(bike))
                .ToList();

            return allUserBikes;
        }

        public BikeAdServiceModelExtended GetById(int id)
        {
            var bikeServiceModel = this.bikeRepository
                .All(bike => bike.Seller)
                .Select(bike => this.mapper.Map<BikeAdServiceModelExtended>(bike))
                .FirstOrDefault();

            return bikeServiceModel;
        }

        public void Update(BikeAdUpdateServiceModel bikeAdUpdateModel)
        {
            var bikeToUpdate = this.bikeRepository.GetById<int>(bikeAdUpdateModel.Id);

            bikeToUpdate.Model = bikeAdUpdateModel.Model;
            bikeToUpdate.Type = (BikeType)bikeAdUpdateModel.Types.Cast<int>().Sum();
            bikeToUpdate.FrameType = bikeAdUpdateModel.FrameType;
            bikeToUpdate.Frame = bikeAdUpdateModel.Frame;
            bikeToUpdate.Handlebar = bikeAdUpdateModel.Handlebar;
            bikeToUpdate.Brakes = bikeAdUpdateModel.Brakes;
            bikeToUpdate.Drivetrain = bikeAdUpdateModel.Drivetrain;
            bikeToUpdate.Suspension = bikeAdUpdateModel.Suspension;
            bikeToUpdate.Fork = bikeAdUpdateModel.Fork;
            bikeToUpdate.RearSuspension = bikeAdUpdateModel.RearSuspension;
            bikeToUpdate.Seatpost = bikeAdUpdateModel.Seatpost;
            bikeToUpdate.Saddle = bikeAdUpdateModel.Saddle;
            bikeToUpdate.TireType = bikeAdUpdateModel.TireType;
            bikeToUpdate.Weight = bikeAdUpdateModel.Weight;
            bikeToUpdate.Gears = bikeAdUpdateModel.Gears;
            bikeToUpdate.Battery = bikeAdUpdateModel.Battery;
            bikeToUpdate.ElectricMotor = bikeAdUpdateModel.ElectricMotor;
            bikeToUpdate.Tires = bikeAdUpdateModel.Tires;
            bikeToUpdate.Price = bikeAdUpdateModel.Price;

            this.bikeRepository.Save();
        }

        public void Delete(int id)
        {
            var bikeToDelete = this.bikeRepository.GetById<int>(id);

            this.bikeRepository.Delete(bikeToDelete);
            this.bikeRepository.Save();
        }
    }
}
