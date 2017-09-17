namespace GeekBrainsWork1.Code
{
    using GeekBrainsWork1.DAL.Context;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AuthorizationModule : AuthorizeAttribute
    {
        private static GeekBrainsWork1Context dbContext = new GeekBrainsWork1Context();

        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!string.IsNullOrEmpty(this.Users))
            {
                this.allowedUsers = this.Users.Split(new[] { ',' });
                for (int i = 0; i < this.allowedUsers.Length; i++)
                {
                    this.allowedUsers[i] = this.allowedUsers[i].Trim();
                }
            }

            if (!string.IsNullOrEmpty(this.Roles))
            {
                this.allowedRoles = this.Roles.Split(',');
                for (int i = 0; i < this.allowedRoles.Length; i++)
                {
                    this.allowedRoles[i] = this.allowedRoles[i].Trim();
                }
            }

            return httpContext.Request.IsAuthenticated &&
                 this.User(httpContext) && this.Role(httpContext);
        }

        private bool User(HttpContextBase httpContext)
        {
            if (this.allowedUsers.Length > 0)
            {
                return this.allowedUsers.Contains(httpContext.User.Identity.Name);
            }

            return true;
        }

        private bool Role(HttpContextBase httpContext)
        {
            if (this.allowedRoles.Length > 0)
            {
                foreach (string dummy in this.allowedRoles)
                {
                    if (dbContext.User.Any(e => e.Login.Trim().ToLower() == httpContext.User.Identity.Name.Trim().ToLower() && e.Role.Name == this.allowedRoles[0]))
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }

        public static bool IsUserAdmin(string login)
        {
            var user = dbContext.User.FirstOrDefault(e => e.Login.Trim().ToLower().Equals(login));
            return user != null && user.Role.Name.Equals("asministrator");
        }
    }
}