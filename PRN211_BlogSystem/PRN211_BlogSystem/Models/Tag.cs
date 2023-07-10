using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
