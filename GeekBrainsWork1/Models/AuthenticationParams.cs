using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeekBrainsWork1.Controllers
{
    public class AuthenticationParams
    {
        [Required(ErrorMessage = "Поле Логин не может быть пустым", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле Пароль не может быть пустым", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}