using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChoreChartThree.Startup))]
namespace ChoreChartThree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
