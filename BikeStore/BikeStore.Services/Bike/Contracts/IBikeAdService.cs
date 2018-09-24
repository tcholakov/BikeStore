namespace BikeStore.Services.Bike.Contracts
{
    using BikeStore.Services.Models.Bike;
    using System.Collections.Generic;

    public interface IBikeAdService
    {
        void Create(BikeAdCreateServiceModel bike);

        IEnumerable<BikeAdServiceModelExtended> GetAllBikes();

        IEnumerable<BikeAdServiceModelExtended> GetAllUserBikes(string userId);

        BikeAdServiceModelExtended GetById(int id);

        void Update(BikeAdUpdateServiceModel bikeAdUpdateModel);

        void Delete(int id);
    }
}
