namespace GeekBrainsWork1.Controllers
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Web.Mvc;
    using System.Web.Security;

    using GeekBrainsWork1.Code;
    using GeekBrainsWork1.DAL.Context;
    using GeekBrainsWork1.Domain.Entities;

    public class AuthenticationController : Controller
    {
        private static GeekBrainsWork1Context dbContext = new GeekBrainsWork1Context();

        [HttpGet]
        public ActionResult LogOn()
        {
            return this.View(new User());
        }

        [HttpPost]
        public ActionResult LogOn(User auth)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!CheckAuthParams(auth))
            {
                ModelState.AddModelError("Login", "Неправильное имя пользователя или пароль");
                return View(auth);
            }

            FormsAuthentication.SetAuthCookie(auth.Login, true);
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        private static bool CheckAuthParams(User auth)
        {
            //var dbContext = new GeekBrainsWork1Context();
            var user = dbContext.User.FirstOrDefault(x => x.Login.Trim().ToLower().Equals(auth.Login.Trim().ToLower()));

            if (user != null)
            {
                return auth.Password.Equals(user.Password);
            }
            
            return false;
        }
    }
}