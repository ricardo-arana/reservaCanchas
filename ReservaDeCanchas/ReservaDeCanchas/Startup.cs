using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReservaDeCanchas.Startup))]
namespace ReservaDeCanchas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
