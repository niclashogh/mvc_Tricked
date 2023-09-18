using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc_Tricked.Data;

namespace mvc_Tricked
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ProfileContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProfileContext") ?? throw new InvalidOperationException("Connection string 'ProfileContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            #region Populate Database (If Database is empty)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }
            #endregion

            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            #endregion

            app.UseHttpsRedirection();

            #region Static Image File Location
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath + "Images")
            });
            #endregion

            app.UseRouting();
            app.UseAuthorization();

            #region Hardcoded Endpoints / Route Directions
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.Map("", async (context) =>
            //    {

            //    });
            //});
            #endregion

            #region Dynamic Endpoint Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.MapControllerRoute(
            //    name: "custom",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            //app.Run(async (HttpContext context) =>
            //{
            //    // Defualt page
            //});

            app.Run();
        }
    }
}