using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class Role
    {
        public Role()
        {
            Features = new HashSet<Feature>();
            Usernames = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<User> Usernames { get; set; }
    }
}
