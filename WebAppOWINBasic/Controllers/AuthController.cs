using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebAppOWINBasic.Models;

namespace WebAppOWINBasic.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(model.UserName.Equals("Nazir",StringComparison.OrdinalIgnoreCase) && model.Password == "Password")
            {
                var identity = new ClaimsIdentity("ApplicationCookie");
                identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,model.UserName),
                    new Claim(ClaimTypes.Name,model.UserName)
                });
                HttpContext.GetOwinContext().Authentication.SignIn(identity);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult LoginFacebook()
        {
            HttpContext.GetOwinContext().Authentication.Challenge(new Microsoft.Owin.Security.AuthenticationProperties {
                RedirectUri="/secret"
            },"Facebook");

            return new HttpUnauthorizedResult();
        }
    }
}