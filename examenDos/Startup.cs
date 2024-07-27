using examenDos.DataBase;
using examenDos.Service;
using examenDos.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace examenDos
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ICustomersService, CustomerService>();

            //add Dbcontext

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("DefaultConnection")));
             




            //ADD AUTOMAPER

            //services.AddAutoMapper(typeof(AutoMapperProfile));

        } 

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
