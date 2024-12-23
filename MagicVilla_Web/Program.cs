using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddHttpClient<IVillaService, VillaService>();
            builder.Services.AddScoped<IVillaService, VillaService>();

            // Register VillaNbService
            builder.Services.AddHttpClient<IVillaNbService, VillaNbService>();
            builder.Services.AddScoped<IVillaNbService, VillaNbService>();

            builder.Services.AddHttpClient<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var app = builder.Build();

            /*
            // Log all activated services
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                foreach (var service in builder.Services)
                {
                    try
                    {
                        var serviceInstance = serviceProvider.GetService(service.ServiceType);
                        if (serviceInstance != null)
                        {
                            Console.WriteLine($"Activated Service: {service.ServiceType.FullName}, Lifetime: {service.Lifetime}, Implementation: {service.ImplementationType?.FullName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to activate service: {service.ServiceType.FullName}. Exception: {ex.Message}");
                    }
                }
            }*/

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
