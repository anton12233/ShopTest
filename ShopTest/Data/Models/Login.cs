using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ShopTest.Data.Models
{
    public class Login
    {


        [Display(Name = "Логин")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длинна имени не менее 5 символов")]
        public string loginName { get; set; }


        [Display(Name = "Пароль")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длинна имени не менее 5 символов")]
        public string password { get; set; }
    }
}
