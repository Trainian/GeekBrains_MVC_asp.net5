namespace GeekBrainsWork1.Code
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AuthorizationModule
    {
        public class MyAuthorizeAttribute : AuthorizeAttribute
        {
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
                        if (EmployeeAndUser.GetUserList().Any(e => e.Name.Trim().ToLower() == httpContext.User.Identity.Name.Trim().ToLower() && e.Roles == this.allowedRoles[0]))
                        {
                            return true;
                        }
                    }

                    return false;
                }

                return true;
            }
        }
    }
}