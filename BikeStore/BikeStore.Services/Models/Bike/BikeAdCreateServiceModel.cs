namespace BikeStore.Services.Models.Bike
{
    using BikeStore.Common.Enums.Bike;
    using System.Collections.Generic;

    public class BikeAdCreateServiceModel
    {
        public string Model { get; set; }
        
        public IEnumerable<BikeType> Types { get; set; }
        
        public FrameType FrameType { get; set; }
        
        public string Frame { get; set; }
        
        public string Handlebar { get; set; }
        
        public string Brakes { get; set; }
        
        public string Drivetrain { get; set; }
        
        public SuspensionType Suspension { get; set; }
        
        public string Fork { get; set; }
        
        public string RearSuspension { get; set; }
        
        public string Seatpost { get; set; }
        
        public string Saddle { get; set; }
        
        public TireType TireType { get; set; }

        public double Weight { get; set; }
        
        public string Gears { get; set; }
        
        public string Battery { get; set; }
        
        public string ElectricMotor { get; set; }
        
        public string Tires { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string SellerId { get; set; }
    }
}
