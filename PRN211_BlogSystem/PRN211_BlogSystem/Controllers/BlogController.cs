using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN211_BlogSystem.Models;

namespace PRN211_BlogSystem.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index(int page)
        {
            using(PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                List<Blog> blogs = new List<Blog>();
                if (page != 0)
                {
                    blogs = context.Blogs
                    .OrderBy(b => b.Id)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .Skip((page-1)>0?(page-1)* 6:0)
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
                if(total % 6 != 0)
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
        public IActionResult Details(int id)
        {
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
               Blog blog = context.Blogs.
                    OrderBy(b => b.Id)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .Include(b => b.Comments)
                    .Where(b => b.Id == id)
                    .FirstOrDefault();
                var categories = context.Categories.ToList();
                ViewBag.categories = categories;
                var blogsThree = context.Blogs
                    .OrderBy(b => b.NoView)
                    .Take(3)
                    .Include(b => b.AuthorNameNavigation)
                    .Include(b => b.Category)
                    .ToList();
                ViewBag.blogsThree = blogsThree;
                return View(blog);
            }
        }
        public IActionResult Delete(int id)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                Blog b = context.Blogs
                    .Include(b => b.Category)
                    .Include(b => b.Comments)
                    .Where(b => b.Id == id)
                    .FirstOrDefault();
                if (b == null)
                {
                    return RedirectToAction("BlogsManager", "Admin");
                }
                else
                {

                    //string sqlDeleteBlogCategory = "DELETE FROM Blog_Category WHERE blogId ={0}";
                    //context.Database.ExecuteSqlRaw(sqlDeleteBlogCategory, id);
                    string sqlDeleteComments = "DELETE FROM Comment WHERE blogId = {0}";
                    context.Database.ExecuteSqlRaw(sqlDeleteComments,id);
                    context.SaveChanges();
                    context.Blogs.Remove(b);
                    context.SaveChanges();
                    return RedirectToAction("BlogsManager", "Admin");
                }
            }

        }
        public IActionResult Update(int id)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                Blog b = context.Blogs
                    .Include(b => b.Category)
                    .Where(b => b.Id == id)
                    .FirstOrDefault();
                if (b == null)
                {
                    return RedirectToAction("BlogsManager", "Admin");
                }
                else
                {
                    var categories = context.Categories.ToList();
                    ViewBag.categories = categories;
                    return View(b);
                }
            }

        }
        [HttpPost]
        public IActionResult Update(Blog updateBlog, IFormFile image)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                Blog b = context.Blogs
                    .Include(b => b.Category)
                    .Where(b => b.Id == updateBlog.Id)
                    .FirstOrDefault();

                if (b == null)
                {
                    return RedirectToAction("BlogsManager", "Admin");
                }
                else
                {
                    b.Title = updateBlog.Title;
                    b.Summary = updateBlog.Summary;
                    b.Content = updateBlog.Content;
                    b.UpdatedAt = DateTime.Now;
                    b.CategoryId = updateBlog.CategoryId;
                    context.SaveChanges();

                    if (image != null && image.Length > 0)
                    {
                        // Check if the file is an image and its extension is ".jpg" or ".jpeg"
                        if (IsImage(image))
                        {
                            // Generate a unique filename using the blog ID
                            string fileName = $"{b.Id}{Path.GetExtension(image.FileName)}";
                            // For demonstration purposes, let's save the image to wwwroot/uploads folder
                            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", fileName);
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                image.CopyTo(fileStream);
                            }
                            // Perform any additional processing on the image if needed
                            // ...

                            // Optionally, redirect to a different action or return a view
                        }
                    }
                }
                return RedirectToAction("BlogsManager", "Admin");

            }
        }

        private bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            // Check the file content type to ensure it's an image
            // You can add more image content types as needed
            return file.ContentType.StartsWith("image/");
        }
        public IActionResult Add()
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                var categories = context.Categories.ToList();
                ViewBag.categories = categories;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(Blog blog, IFormFile image)
        {
            string role = HttpContext.Session.GetString("role");
            if (role == null || role != "Admin")
            {
                return RedirectToAction("NotFound", "Home");
            }
            using (PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                blog.CreateAt = DateTime.Now;
                blog.UpdatedAt = DateTime.Now;
                blog.MetaTitle = blog.Title;
                blog.AuthorName = HttpContext.Session.GetString("username");
                context.Blogs.Add(blog);
                context.SaveChanges();
                blog.Image = blog.Id + ".jpg";
                context.SaveChanges();
                if (image != null && image.Length > 0)
                {
                    // Check if the file is an image and its extension is ".jpg" or ".jpeg"
                    if (IsImage(image))
                    {
                        // Generate a unique filename using the blog ID
                        string fileName = $"{blog.Id}{Path.GetExtension(image.FileName)}";
                        // For demonstration purposes, let's save the image to wwwroot/uploads folder
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                        }
                        // Perform any additional processing on the image if needed
                        // ...

                        // Optionally, redirect to a different action or return a view
                    }
                }
                return RedirectToAction("BlogsManager", "Admin");
            }

        }

    }

}
