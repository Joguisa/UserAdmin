using BackUserAdmin.DataContext;
using BackUserAdmin.Services.Contrato;
using BackUserAdmin.Services.Implementacion;
using Microsoft.EntityFrameworkCore;

namespace BackUserAdmin
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Registrar AutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<AppDbContext>(options =>
                           options.UseSqlServer(Configuration.GetConnectionString("cadenaSQL")).EnableSensitiveDataLogging()
            );

            // cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            //inject services
            services.AddScoped<IUser, UserService>();
            services.AddScoped<ICargo, CargoService>();
            services.AddScoped<IDepartamento, DepartamentoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
