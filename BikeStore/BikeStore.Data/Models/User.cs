namespace BikeStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<BikeAd> Bikes { get; set; } = new List<BikeAd>();
    }
}
