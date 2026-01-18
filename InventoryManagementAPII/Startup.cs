using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InventoryManagement.BLL.Interface;
using InventoryManagement.BLL;
using InventoryManagement.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using InventoryManagement.Entity.Models;
using InventoryManagement.BLL.Service;
using InventoryManagement.Common.TokenHelper;

namespace InventoryManagementAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
                    .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IUserStore<ApplicationUser>, UserStoreService>();
            services.AddTransient<IRoleStore<ApplicationRole>, RoleStoreService>();

            services.AddIdentity<ApplicationUser, ApplicationRole>().AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Read Data From the configuration file
            InventoryManagementSettings.ConnectionString = Configuration.GetSection("ConnectionString:InventoryManagementEntities").Value;

            // Add framework services.
            //services.AddCors(options =>
            //{
            //	options.AddPolicy("AllowAllOrigins",
            //				builder =>
            //				{
            //			builder.AllowAnyOrigin()
            //						.AllowAnyMethod()
            //						.AllowAnyHeader()
            //						.WithExposedHeaders("x-custom-header").SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
            //		});
            //});


            services.AddApplicationInsightsTelemetry(Configuration);
            DependencyResolver(services);

            //services.AddMvc().
            //AddJsonOptions(options =>
            //		{
            //			options.SerializerSettings.ContractResolver
            //													 = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            //		});

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // ===== Jwt Configuration ===== 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "Fiver.Security.Bearer",
                            ValidAudience = "Fiver.Security.Bearer",
                            IssuerSigningKey = JwtSecurityKey.Create()
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            InventoryManagementSettings.ImagePathUrl = env.WebRootPath;

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.Options.StartupTimeout = new TimeSpan(0, 1, 80);
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            //app.UseCors("AllowAllOrigins");
            //app.MapWhen(context => context.Request.Path.Value.StartsWith("/web"), builder =>
            //{
            //    builder.UseMvc(routes =>
            //    {
            //        routes.MapSpaFallbackRoute("Web-Admin", new { controller = "Web", action = "Index" });
            //    });
            //});
            //app.UseMvc();


            app.UseAuthentication();
        }

        private void DependencyResolver(IServiceCollection services)
        {
            //services.AddSingleton<IRoleManagement, RoleManagementService>();
            services.AddSingleton<IAreaService, AreaService>();
            services.AddSingleton<ICityService, CityService>();
            services.AddSingleton<IStateService, StateService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IPermissionService, PermissionService>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<IColorService, ColorService>();
            services.AddSingleton<IStyleService, StyleService>();
            services.AddSingleton<IItemGroupService, ItemGroupService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IDesignNoService, DesignNoService>();
            services.AddSingleton<ISizeService, SizeService>();
            services.AddSingleton<ISizeGroupService, SizeGroupService>();
            services.AddSingleton<ISizeGroupSizeService, SizeGroupSizeService>();
            services.AddSingleton<IGlobalSettingService, GlobalSettingService>();
            services.AddSingleton<IHSNCodeService, HSNCodeService>();
            services.AddSingleton<ITaxService, TaxService>();
            services.AddSingleton<IAccountCategoryService, AccountCategoryService>();
            services.AddSingleton<ICustomerCategoryService, CustomerCategoryService>();
            services.AddSingleton<IAccountGroupService, AccountGroupService>();
        
            services.AddSingleton<IFinancialYearService, FinancialYearService>();
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IBranchService, BranchService>();
            services.AddSingleton<ITermsNCondition, TermsNConditionService>(); 
        }
    }
}

