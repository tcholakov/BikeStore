namespace BikeStore.Web.Models.Bikes
{
    using BikeStore.Common.Enums.Bike;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BikeAdShortViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        [Display(Name = "Type")]
        public IEnumerable<BikeType> Types { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Seller username")]
        public string SellerUsername { get; set; }
    }
}
