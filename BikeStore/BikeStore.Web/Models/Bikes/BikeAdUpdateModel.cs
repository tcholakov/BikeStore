namespace BikeStore.Web.Models.Bikes
{
    using System.ComponentModel.DataAnnotations;
    
    public class BikeAdUpdateModel : BikeAdCreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}
