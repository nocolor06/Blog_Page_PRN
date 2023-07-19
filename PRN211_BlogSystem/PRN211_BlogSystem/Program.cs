namespace PRN211_BlogSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            var app = builder.Build();
            app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=HomePage}/{id?}"
			);

            app.UseSession();
            app.UseStaticFiles();

            app.Run();
		}
	}
}