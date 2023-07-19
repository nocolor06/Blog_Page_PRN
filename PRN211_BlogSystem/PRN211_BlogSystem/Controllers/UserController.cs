using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN211_BlogSystem.Models;

namespace PRN211_BlogSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String username,String password)
        {
            using(PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                User user = context.Users
                    .Include(u => u.Roles)
                    .Where(u => u.Username.Equals(username) && u.Password.Equals(password))
                    .FirstOrDefault();
                if(user == null)
                {
                    ViewBag.errorLogin = "Invalid username or password";
                }
                else
                {
                    HttpContext.Session.SetString("username", username);
                    foreach (Role r in user.Roles)
                    {
                        if(r.Name == "Admin")
                        {
                            HttpContext.Session.SetString("role", r.Name);
                            break;
                        }
                    }
                    string role = HttpContext.Session.GetString("role");
                    if(role == null)
                    {
                        HttpContext.Session.SetString("role", "Customer");
                    }
                    return RedirectToAction("Index","Blog");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Blog");
        }
    }
}
