using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class Feature
    {
        public Feature()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}
