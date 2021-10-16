using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Routing;

using AssetMan_WebApp.Services;
using AssetMan_WebApp.DAL;
//
using AssetMan.UseCases.RepositoryPlugins;
using AssetMan.Plugins.Repository.SqliteDb;
using AssetMan.UseCases.AssetScreen;
using AssetMan.UseCases.CategoryScreen;
using AssetMan.UseCases.FinnCategoryScreen;
using AssetMan.UseCases.ContactScreen;
using AssetMan.UseCases.LocationScreen;






namespace AssetMan.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IWebHostEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddTransient(typeof(UserService));
            services.AddEntityFrameworkSqlite()
                .AddDbContext<StudentDbContext>(options =>
                {
                    options.UseSqlite(Configuration.GetConnectionString("Authentication"));
                });
            //
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<StudentDbContext>()
                .AddDefaultTokenProviders();
			services.ConfigureApplicationCookie(o => { o.LoginPath = new PathString("/Authentication/SignIn"); });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Authentication/SignIn";
                });
            //Config thêm ở đây, còn nhiều thứ khác.
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
            });


            services.AddDotVVM<DotvvmStartup>();

            //    Database
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IFinanceCategoryRepository, FinanceCategoryRepository>();
            services.AddSingleton<ILocationRepository, LocationRepository>();
            services.AddSingleton<IContactRepository, ContactRepository>();
            services.AddSingleton<IAssetRepository, AssetRepository>();

            services.AddTransient<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
            services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
            services.AddTransient<ICreateCategoryUseCase, CreateCategoryUseCase>();
            services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            services.AddTransient<IIsCategoryIdAvailableUseCase, IsCategoryIdAvailableUseCase>();
            //CA: FCategory

            services.AddTransient<IGetAllFinanceCategoriesUseCase, GetAllFinanceCategoriesUseCase>();
            services.AddTransient<IGetFinanceCategoryByIdUseCase, GetFinanceCategoryByIdUseCase>();
            services.AddTransient<ICreateFinanceCategoryUseCase, CreateFinanceCategoryUseCase>();
            services.AddTransient<IUpdateFinanceCategoryUseCase, UpdateFinanceCategoryUseCase>();
            //CA: Location

            services.AddTransient<IGetAllLocationsUseCase, GetAllLocationsUseCase>();
            services.AddTransient<IGetLocationByIdUseCase, GetLocationByIdUseCase>();
            services.AddTransient<ICreateLocationUseCase, CreateLocationUseCase>();
            services.AddTransient<IUpdateLocationUseCase, UpdateLocationUseCase>();
            //CA: Contact

            services.AddTransient<IGetAllContactsUseCase, GetAllContactsUseCase>();
            services.AddTransient<IGetContactByIdUseCase, GetContactByIdUseCase>();
            services.AddTransient<ICreateContactUseCase, CreateContactUseCase>();
            services.AddTransient<IUpdateContactUseCase, UpdateContactUseCase>();
            //CA: Asset
            services.AddTransient<IGetAllAssetViewsUseCase, GetAllAssetViewsUseCase>();
            services.AddTransient<IGetAssetsByCategoryUseCase, GetAssetsByCategoryUseCase>();
            services.AddTransient<IGetAssetByIdUseCase, GetAssetByIdUseCase>();
            services.AddTransient<ICreateAssetUseCase, CreateAssetUseCase>();
            services.AddTransient<IUpdateAssetUseCase, UpdateAssetUseCase>();          
                      

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            )
        {

			app.UseAuthentication();
            // use DotVVM
            var dotvvmConfiguration = app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);
            dotvvmConfiguration.AssertConfigurationIsValid();
            
            // use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });

            
        }
        
    }
}
