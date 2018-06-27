using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebAppOWINBasic.Middleware;

namespace WebAppOWINBasic
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            app.Use<DebugMiddleware>();

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType="ApplicationCookie",
                LoginPath=new Microsoft.Owin.PathString("/Auth/Login")
            });

            app.UseFacebookAuthentication(new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            {
                AppId = "1299763110157051",
                AppSecret = "90e4cb41a1b7ae0679e8500a176f43e6",
                SignInAsAuthenticationType= "ApplicationCookie"
            });

            //app.Run(async (ctx) =>
            //await ctx.Response.WriteAsync("Hello World!"));
        }
    }
}