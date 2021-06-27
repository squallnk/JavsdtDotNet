using Javsdt.API.SQL;
using Javsdt.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Javsdt.API
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
            // WebApi控制器
            services.AddControllers();
            // 数据库连接
            //services.AddDbContext<JavsdtContext>(options => options.UseSqlite(@$"Data Source={EnvSettings.ProjectDirectory}\Javsdt.db"));
            //System.Console.WriteLine(@$"Data Source={EnvSettings.ProjectDirectory}\Javsdt.db");
            services.AddDbContext<JavsdtContext>(options => options.UseSqlite(@$"Data Source={EnvSettings.ProjectDirectory}\Javsdt.db"));
            // 数据库EF服务
            services.AddScoped<GetRepository>();
            // 允许所有请求
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
