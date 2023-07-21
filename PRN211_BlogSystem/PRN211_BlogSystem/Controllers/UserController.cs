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
            HttpContext.Session.Remove("role");

            return RedirectToAction("Index", "Blog");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User registerUser)
        {
            using(PRN211_BlogSystemContext context = new PRN211_BlogSystemContext())
            {
                User findUser = context.Users.Where(u => u.Username.Equals(registerUser.Username)).FirstOrDefault();
                if(findUser == null)
                {
                    registerUser.RegisterAt = DateTime.Now;
                    registerUser.LastLogin = DateTime.Now;

                    string sqlInsertUser = "INSERT INTO [User](username,password,displayName,email,dob,phoneNumber,registerAt,lastLogin)" +
                        "\n VALUES ({0},{1},{2},{3},{4},{5},{6},{7})";
                    context.Database.ExecuteSqlRaw(sqlInsertUser, registerUser.Username, registerUser.Password,registerUser.DisplayName,
                        registerUser.Email,registerUser.Dob.Year+"-"+registerUser.Dob.Month+"-"+registerUser.Dob.Day,registerUser.PhoneNumber,
                        registerUser.RegisterAt,registerUser.LastLogin);
                    context.SaveChanges();
                    string sqlDeleteComments = "INSERT INTO User_Role(username,roleId) VALUES ({0},{1})";
                    context.Database.ExecuteSqlRaw(sqlDeleteComments, registerUser.Username,2);
                    context.SaveChanges();
                    HttpContext.Session.SetString("username", registerUser.Username);
                    HttpContext.Session.SetString("role", "Customer");
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    ViewBag.errorRegister = "Username is taken";
                    return View(registerUser);
                }
            }
            return View();
        }
    }
}
