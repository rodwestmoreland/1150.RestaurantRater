using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1150.RestaurantRater.Startup))]
namespace _1150.RestaurantRater
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
