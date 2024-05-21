using MeetUp.DataAccesLayer;
using Microsoft.EntityFrameworkCore;

namespace MeetUp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<MeetUpContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        
        var app = builder.Build();
     
        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllerRoute("areas", "{area:exists}/{controller=Speaker}/{action=Index}/{id?}");
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        app.Run();

    }
}
