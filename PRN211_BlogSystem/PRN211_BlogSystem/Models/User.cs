using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<Comment>();
            Roles = new HashSet<Role>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime RegisterAt { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
