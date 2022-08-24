using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Startup
    {
        public static WebApplication api(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfirugeServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void ConfirugeServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<ICarDal, EfCarDal>();
            builder.Services.AddSingleton<IBrandService, BrandManager>();
            builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }



        private static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
