namespace BikeStore.Data.Models
{   
    using System.ComponentModel.DataAnnotations;
    using BikeStore.Common.Constants;
    using BikeStore.Common.Enums.Bike;

    public class BikeAd
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Model { get; set; }

        [Required]
        public BikeType Type { get; set; }

        [Required]
        public FrameType FrameType { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Frame { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Handlebar { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Brakes { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Drivetrain { get; set; }

        [Required]
        public SuspensionType Suspension { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Fork { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string RearSuspension { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Seatpost { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Saddle { get; set; }

        [Required]
        public TireType TireType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Weight { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Gears { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Battery { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string ElectricMotor { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Tires { get; set; }

        [Required]
        public string SellerId { get; set; }

        public User Seller { get; set; }

        [MaxLength(BikeConstants.LongDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        
    }
}
