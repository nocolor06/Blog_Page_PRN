using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PRN211_BlogSystem.Controllers
{
	public class HomeController : Controller
	{
		// GET: HomeController
		public ActionResult HomePage()
		{
			return View();
		}

		
	}
}
