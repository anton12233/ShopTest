using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopTest.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длинна имени не менее 5 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длинна фамилии не менее 5 символов")]
        public string surname { get; set; }

        [Display(Name = "Адресс")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Длинна адреса не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "Длинна номера не менее 10 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength: 100, MinimumLength = 15, ErrorMessage = "Длинна email не менее 15 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        
        [BindNever]
        public List<OrderDetail> orderDerails { get; set; }

        [BindNever]
        public int userID { get; set; }


    }
}
