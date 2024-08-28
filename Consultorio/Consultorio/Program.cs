
using Consultorio.Context;
using Consultorio.Services;
using Microsoft.EntityFrameworkCore;

namespace Consultorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            string mySqlConnection =
               builder.Configuration.GetConnectionString("Default");


            //assembly => assembly.MigrationsAssembly(typeof(ConsultorioContext).Assembly.FullName));

            builder.Services.AddDbContextPool<ConsultorioContext>(options =>
                            options.UseMySql(mySqlConnection,
                                  ServerVersion.AutoDetect(mySqlConnection)));


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IEmailService, EmailService>();


            var app = builder.Build();

           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.MapControllers();

            app.Run();
        }
    }
}
