using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _1150.RestaurantRater.Models
{
    public class RestaurantDBContext:DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}