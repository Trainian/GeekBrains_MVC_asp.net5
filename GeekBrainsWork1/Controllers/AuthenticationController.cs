namespace GeekBrainsWork1.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;

    using GeekBrainsWork1.Code;
    using GeekBrainsWork1.DAL.Context;

    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult LogOn()
        {
            return this.View(new AuthenticationParams());
        }

        [HttpPost]
        public ActionResult LogOn(AuthenticationParams auth)
        {
            if (!ModelState.IsValid)
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
            var dbContext = new GeekBrainsWork1Context();
            var user = dbContext.User.FirstOrDefault(x => x.Login.Trim().ToLower().Equals(auth.Name.Trim().ToLower()));

            if (user != null)
            {
                return auth.Password.Equals(user.Password);
            }
            
            return false;
        }
    }
}