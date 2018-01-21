using System.IO;
using ClickerModels;
using ClickerRepository;
using ClickerRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClickerService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            var c = Configuration.GetConnectionString("database");//.GetConnectionString("database");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<DatabaseProvider>();

            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IShopItemsRepository, ShopItemsRepository>();
            services.AddScoped<IPlayerShopItemsRepository, PlayerShopItemsRepository>();
            services.AddScoped<IRankingsRepository, RankingsRepository>();
            services.AddScoped<IFacebookRankingsRepository, FacebookRankingsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
