using System;
using System.Collections.Generic;

namespace PRN211_BlogSystem.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
            Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string AuthorName { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string MetaTitle { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int NoView { get; set; }

        public virtual User AuthorNameNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
