//using Kontrola.Repositories;
//using Kontrola.Repositories.Interfaces;
//using Kontrola.Services;
using Kontrola.Context;
using Kontrola.Models;
using Kontrola.Repositories;
using Kontrola.Repositories.Interfaces;
using Kontrola.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
// Unused usings removed.

namespace WebAppRPv5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddTransient<IChamadoRepository, ChamadoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IGravidadeRepository, GravidadeRepository>();
            services.AddTransient<IModalidadeRepository, ModalidadeRepository>();
            services.AddTransient<IStatusRepository, StatusRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUrgenciaRepository, UrgenciaRepository>();
            services.AddTransient<ITendenciaRepository, TendenciaRepository>();
            services.AddTransient<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();


            services.AddMemoryCache();
            services.AddSession();



        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            //cria perfil
            seedUserRoleInitial.SeedRoles();
            //cria os usuarios e atribui o perfil 
            seedUserRoleInitial.SeedUsers();


            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}