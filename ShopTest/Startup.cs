using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopTest.Data;
using ShopTest.Data.Repository;
using ShopTest.Data.Interfaces;
using ShopTest.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopTest.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

//https://itproger.com/course/asp-net/10
//https://metanit.com/sharp/aspnet5/
/*
TO DO
* Личный кабинет
    + данные доставки по умолчанию
    + информация о заказах

* 3 вида ролей 
    + Админ - добавляет менеджеров
    + Менеджер - добавляет и удаляет позиции
    + Покупатель - создаёт заказы

* Добавить слайдер на главную страницу

 */

namespace ShopTest
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment confString)
        {
            _confString = new ConfigurationBuilder().SetBasePath(confString.ContentRootPath).AddJsonFile("dbsetting.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();
            services.AddTransient<IAllLogin, LoginRepositoy>();
            services.AddTransient<IAllUser, UserRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.getCart(sp));
            services.AddScoped(sp => Auth.getAuth(sp));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Login/Logining");
            services.AddAuthorization();


            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseAuthentication();   
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new {Controller = "Car", action = "List"});
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
