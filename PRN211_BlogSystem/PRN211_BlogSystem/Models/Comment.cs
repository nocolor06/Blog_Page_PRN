using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }

        public virtual User AuthorNameNavigation { get; set; } = null!;
        public virtual Blog Blog { get; set; } = null!;
    }
}
