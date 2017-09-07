using GeekBrainsWork1.Code;
using GeekBrainsWork1.Content;
using GeekBrainsWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GeekBrainsWork1.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpGet]
        public ActionResult LogOn()
        {
            return View(new AuthenticationParams { });
        }

        [HttpPost]
        public ActionResult LogOn(AuthenticationParams auth)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            if (!CheckAuthParams(auth))
            {
                ModelState.AddModelError("Name", "Неправильное имя пользователя или пароль");
                return View(auth);
            }
            FormsAuthentication.SetAuthCookie(auth.Name, auth.RememberMe);
            return Redirect(FormsAuthentication.DefaultUrl);
        }
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.DefaultUrl);
        }


        private static bool CheckAuthParams(AuthenticationParams auth)
        {
            var user = EmployeeAndUser.GetUserList().FirstOrDefault(x => x.Name.Trim().ToLower().Equals(auth.Name.Trim().ToLower()));

            if (user != null)
                return auth.Password.Equals(user.Password);

            return false;
        }
    }
}