using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AmaraCode.CManager.Infrastructure;
using AmaraCode.CManager.Models;
using AmaraCode.CManager.AppServices;

namespace cmanager
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
            // Add framework services.
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<CompanyAppService, CompanyAppService>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            
            
            services.AddControllersWithViews();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //load the initial data objects
            InitializeData(env);
        }

        private void InitializeData(IWebHostEnvironment env)
        {
            //create 
            var repo = new CompanyRepository(env);

            /*
            string datapath = $@"{env.ContentRootPath}\data";
            //Load company data
            try
            {
                var cdata = new FileIO<List<Company>, Company>(datapath);
                DataContext.Companies = cdata.GetData(DataContext.Companies);
            }
            catch
            {}

            //Load conversation data
            try
            {
                var convData = new FileIO<List<Conversation>, Conversation>(datapath);
                DataContext.Conversations = convData.GetData(DataContext.Conversations);

            }
            catch
            { }
            */
        }
    }
}
