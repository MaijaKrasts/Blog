using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Admin
{
    public class AdminModel
    {
        public List<Data.Entities.User> AllUsers { get; set; }

        public List<Data.Entities.User> WritingUsers { get; set; }

        public List<Data.Entities.User> CommentingUsers { get; set; }

        public List<Data.Entities.User> RatingUsers { get; set; }

        public List<Data.Entities.User> Admins { get; set; }
    }
}