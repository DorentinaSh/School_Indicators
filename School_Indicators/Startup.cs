using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(School_Indicators.Startup))]
namespace School_Indicators
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
