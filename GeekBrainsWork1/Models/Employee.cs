using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeekBrainsWork1.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [StringLength(250)]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательной")]
        [StringLength(250)]
        [DisplayName("Фамилия")]
        public string SurName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество является обязательным")]
        [StringLength(250)]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения является обязательной")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}", ConvertEmptyStringToNull = true)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }
    }
}