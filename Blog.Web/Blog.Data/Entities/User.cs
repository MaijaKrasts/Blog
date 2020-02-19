using Blog.Data.Base;

namespace Blog.Data.Entities
{
    public class User : BaseData
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int Role { get; set; }

        public int CanComment { get; set; }

        public int CanRate { get; set; }

        public int CanWrite { get; set; }
    }
}
