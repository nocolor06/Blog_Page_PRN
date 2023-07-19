using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN211_BlogSystem.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string AuthorName { get; set; } = null!;
        public string? Image { get; set; }
        public string Title { get; set; } = null!;
        public string? MetaTitle { get; set; }
        public string Summary { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? NoView { get; set; }
        public int CategoryId { get; set; }

        public virtual User AuthorNameNavigation { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
