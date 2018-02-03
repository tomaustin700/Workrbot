using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Workrbot.Data;

[assembly: OwinStartup(typeof(Workrbot.Startup))]

namespace Workrbot
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext(WorkrBotContext.Create);

        }

       
    }
}
