using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.User
{
    public class UserDataModel
    {
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert email!!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(16)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
        public string Picture { get; set; }
    }
}