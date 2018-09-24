namespace BikeStore.Web.Models.Bikes
{
    using BikeStore.Common.Constants;
    using BikeStore.Common.Enums.Bike;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BikeAdCreateModel
    {
        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Model { get; set; }

        [Required]
        public IEnumerable<BikeType> Types { get; set; }

        [Required]
        [Display(Name = "Frame type")]
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
        [Display(Name = "Suspension type")]
        public SuspensionType Suspension { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Fork { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        [Display(Name = "Rear suspension (optional)")]
        public string RearSuspension { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        [Display(Name = "Seatpost (optional)")]
        public string Seatpost { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Saddle { get; set; }

        [Required]
        [Display(Name = "Tire type")]
        public TireType TireType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Display(Name = "Weight in kg")]
        public double Weight { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        [Display(Name = "Gears (optional)")]
        public string Gears { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        [Display(Name = "Battery (optional)")]
        public string Battery { get; set; }

        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        [Display(Name = "Electric motor (optional)")]
        public string ElectricMotor { get; set; }

        [Required]
        [MaxLength(BikeConstants.ShortDescriptionMaxLength)]
        public string Tires { get; set; }

        [MaxLength(BikeConstants.LongDescriptionMaxLength)]
        [Display(Name = "Description (optional)")]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
