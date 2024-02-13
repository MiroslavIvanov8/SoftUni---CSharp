using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Services;
using TaskBoardApp.Services.Interfaces;

namespace TaskBoardApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TaskBoardDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration.GetSection("Identity").GetSection("SignIn")
                    .GetValue<bool>("RequireConfirmedAccount");
                options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase = builder.Configuration.GetSection("Identity").GetSection("Password")
                    .GetValue<bool>("RequireUppercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration.GetSection("Identity").GetSection("Password")
                    .GetValue<bool>("RequireNonAlphanumeric");
                options.Password.RequiredLength = builder.Configuration.GetSection("Identity").GetSection("Password")
                    .GetValue<int>("RequiredLength");

            }).AddEntityFrameworkStores<TaskBoardDbContext>();

            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IBoardService, BoardService>();
            builder.Services.AddScoped<ITaskService, TaskService>();

            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}