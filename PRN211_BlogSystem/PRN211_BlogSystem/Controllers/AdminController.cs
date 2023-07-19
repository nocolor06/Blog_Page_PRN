using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN211_BlogSystem.Models;

namespace PRN211_BlogSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult BlogsManager(int page)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                List<Blog> blogs = new List<Blog>();
                if (page != 0)
                {
                    blogs = context.Blogs
                    .OrderBy(b => b.Id)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .Skip((page - 1) > 0 ? (page - 1) * 6 : 0)
                    .Take(6)
                    .ToList();
                }
                else
                {
                    blogs = context.Blogs
                    .OrderBy(b => b.Id)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .Skip(0)
                    .Take(6)
                    .ToList();
                    page = 1;
                }
                int count = context.Blogs.ToList().Count;
                int total = count / 6;
                if (total % 6 != 0)
                {
                    total++;
                }
                var categories = context.Categories.ToList();
                ViewBag.categories = categories;
                var blogsThree = context.Blogs
                    .OrderBy(b => b.NoView)
                    .Take(3)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .ToList();
                ViewBag.blogsThree = blogsThree;
                ViewBag.page = page;
                ViewBag.total = total;
                ViewBag.blogs = blogs;
            }
            return View();
        }
    }
}
