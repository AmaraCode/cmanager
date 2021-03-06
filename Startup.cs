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
using AmaraCode.CManager.AppService;

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
            services.AddTransient<ConversationAppService, ConversationAppService>();
            services.AddTransient<HomeAppService, HomeAppService>();
            services.AddTransient<PersonAppService, PersonAppService>();

            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IConversationRepository, ConversationRepository>();
            
            
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
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //load the initial data objects
            InitializeData(env);
        }



        private void InitializeData(IWebHostEnvironment env)
        {
            DataContext.Path = $@"{env.ContentRootPath}\data";

            //load company data
            try
            {
                var c = new FileIO<Dictionary<Guid, Company>, Company>(DataContext.Path);
                DataContext.Companies = c.GetData(DataContext.Companies);
            }
            catch
            {
            }


            //load conversation data
            try
            {
                var cv = new FileIO<Dictionary<Guid, Conversation>, Conversation>(DataContext.Path);
                DataContext.Conversations = cv.GetData(DataContext.Conversations);
            }
            catch
            {
            }
        }
    }
}
