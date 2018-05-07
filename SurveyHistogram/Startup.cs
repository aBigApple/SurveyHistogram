using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyHistogram.Startup))]
namespace SurveyHistogram
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
