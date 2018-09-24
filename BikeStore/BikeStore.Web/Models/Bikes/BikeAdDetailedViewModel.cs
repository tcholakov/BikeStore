namespace BikeStore.Web.Models.Bikes
{
    using BikeStore.Common.Enums.Bike;
    using System.ComponentModel.DataAnnotations;

    public class BikeAdDetailedViewModel : BikeAdShortViewModel
    {
        [Display(Name = "Frame type")]
        public FrameType FrameType { get; set; }
        
        public string Frame { get; set; }
        
        public string Handlebar { get; set; }
        
        public string Brakes { get; set; }
        
        public string Drivetrain { get; set; }
        
        [Display(Name = "Suspension type")]
        public SuspensionType Suspension { get; set; }
        
        public string Fork { get; set; }
        
        [Display(Name = "Rear suspension")]
        public string RearSuspension { get; set; }
        
        public string Seatpost { get; set; }
        
        public string Saddle { get; set; }
        
        [Display(Name = "Tire type")]
        public TireType TireType { get; set; }
        
        [Display(Name = "Weight in kg")]
        public double Weight { get; set; }
        
        public string Gears { get; set; }
        
        public string Battery { get; set; }
        
        [Display(Name = "Electric motor")]
        public string ElectricMotor { get; set; }
        
        public string Tires { get; set; }

        public string Description { get; set; }

        public string SellerId { get; set; }
    }
}
