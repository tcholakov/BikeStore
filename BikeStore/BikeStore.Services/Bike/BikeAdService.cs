namespace BikeStore.Services.Bike
{
    using BikeStore.Services.Bike.Contracts;
    using BikeStore.Services.Models.Bike;
    using BikeStore.Data.Models;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using BikeStore.Common.Enums.Bike;
    using BikeStore.Data;
    using Microsoft.EntityFrameworkCore;

    public class BikeAdService : IBikeAdService
    {
        private readonly BikeStoreDbContext dbContext;
        private readonly IMapper mapper;

        public BikeAdService(BikeStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Create(BikeAdCreateServiceModel bike)
        {
            var bikeToCreate = this.mapper.Map<BikeAd>(bike);

            this.dbContext.Bikes.Add(bikeToCreate);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<BikeAdServiceModelExtended> GetAllBikes()
        {
            var allBikes = this.dbContext
                .Bikes
                .Include(bike => bike.Seller)
                .Select(bike => this.mapper.Map<BikeAdServiceModelExtended>(bike))
                .ToList();

            return allBikes;
        }

        public IEnumerable<BikeAdServiceModelExtended> GetAllUserBikes(string userId)
        {
            var allUserBikes = this.dbContext
                .Bikes
                .Include(bike => bike.Seller)
                .Where(bike => bike.SellerId.Equals(userId))
                .Select(bike => this.mapper.Map<BikeAdServiceModelExtended>(bike))
                .ToList();

            return allUserBikes;
        }

        public BikeAdServiceModelExtended GetById(int id)
        {
            var bike = this.dbContext
                .Bikes
                .Find(id);

            var bikeServiceModel = this.mapper.Map<BikeAdServiceModelExtended>(bike);

            return bikeServiceModel;
        }

        public void Update(BikeAdUpdateServiceModel bikeAdUpdateModel)
        {
            var bikeToUpdate = this.dbContext.Bikes.Find(bikeAdUpdateModel.Id);

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

            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var bikeToDelete = this.dbContext.Bikes.Find(id);

            this.dbContext.Bikes.Remove(bikeToDelete);
            this.dbContext.SaveChanges();
        }
    }
}
