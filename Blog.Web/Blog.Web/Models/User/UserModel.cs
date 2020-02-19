using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public IFormFile UpdatedPicture { get; set; }

        public string Picture { get; set; }
    }
}