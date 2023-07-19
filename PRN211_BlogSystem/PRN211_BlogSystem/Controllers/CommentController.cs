using Microsoft.AspNetCore.Mvc;
using PRN211_BlogSystem.Models;

namespace PRN211_BlogSystem.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public IActionResult Add(String message,int blogId)
        {
            string username = HttpContext.Session.GetString("username");
            if(username == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            else
            {
                Comment comment = new Comment();
                comment.BlogId = blogId;
                comment.AuthorName = username;
                comment.Content = message;
                comment.CreateAt = DateTime.Now;
                using(PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
                {
                    context.Comments.Add(comment);
                    context.SaveChanges();
                    return RedirectToAction("Details", "Blog", new { id = blogId });
                }
            }
        }
    }
}
