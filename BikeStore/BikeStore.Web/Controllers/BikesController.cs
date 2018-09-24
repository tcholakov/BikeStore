namespace BikeStore.Web.Controllers
{
    using AutoMapper;
    using BikeStore.Data.Models;
    using BikeStore.Services.Bike.Contracts;
    using BikeStore.Services.Models.Bike;
    using BikeStore.Web.Models.Bikes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class BikesController : Controller
    {
        private readonly IBikeAdService bikeAdService;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public BikesController(IBikeAdService bikeAdService, UserManager<User> userManager, IMapper mapper)
        {
            this.bikeAdService = bikeAdService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Authorize]
        public IActionResult Create(BikeAdCreateModel createBikeAdModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createBikeAdModel);
            }

            var bikeToCreate = this.mapper.Map<BikeAdCreateServiceModel>(createBikeAdModel);
            bikeToCreate.SellerId = this.userManager.GetUserId(this.User);

            this.bikeAdService.Create(bikeToCreate);

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            var allBikes = this.bikeAdService
                .GetAllBikes()
                .Select(bikeServiceModelExtended => this.mapper.Map<BikeAdShortViewModel>(bikeServiceModelExtended))
                .ToList();

            return this.View(allBikes);
        }

        public IActionResult MyBikeAds()
        {
            string userId = this.userManager.GetUserId(this.User);

            var myBikes = this.bikeAdService
                .GetAllUserBikes(userId)
                .Select(bikeServiceModelExtended => this.mapper.Map<BikeAdShortViewModel>(bikeServiceModelExtended))
                .ToList();

            return this.View(myBikes);
        }

        public IActionResult Details(int id)
        {
            var bikeServiceModel = this.bikeAdService.GetById(id);
            var bikeDetailedViewModel = this.mapper.Map<BikeAdDetailedViewModel>(bikeServiceModel);

            return this.View(bikeDetailedViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            string userId = this.userManager.GetUserId(this.User);
            var bikeForDeletion = this.bikeAdService.GetById(id);

            if (!userId.Equals(bikeForDeletion.SellerId))
            {
                this.View("Error");
            }

            this.bikeAdService.Delete(id);

            return this.RedirectToAction(nameof(Index));
        }


        [Authorize]
        public IActionResult Update(int id)
        {
            string userId = this.userManager.GetUserId(this.User);
            var bikeForUpdate = this.bikeAdService.GetById(id);

            if (!userId.Equals(bikeForUpdate.SellerId))
            {
                this.View("Error");
            }

            var bikeInputModel = this.mapper.Map<BikeAdUpdateModel>(bikeForUpdate);

            return this.View(bikeInputModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(BikeAdUpdateModel updateBikeAdModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(updateBikeAdModel);
            }

            string userId = this.userManager.GetUserId(this.User);
            var bikeMarkedForUpdate = this.bikeAdService.GetById(updateBikeAdModel.Id);

            if (!userId.Equals(bikeMarkedForUpdate.SellerId))
            {
                this.View("Error");
            }

            var bikeUpdateServiceModel = this.mapper.Map<BikeAdUpdateServiceModel>(updateBikeAdModel);
            this.bikeAdService.Update(bikeUpdateServiceModel);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
