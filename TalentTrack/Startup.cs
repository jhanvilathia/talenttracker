using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TalentTrack.Startup))]
namespace TalentTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
