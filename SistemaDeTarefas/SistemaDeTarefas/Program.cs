using Microsoft.EntityFrameworkCore;
using Refit;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Integracao;
using SistemaDeTarefas.Integracao.Interfaces;
using SistemaDeTarefas.Integracao.Refit;
using SistemaDeTarefas.Repository;
using SistemaDeTarefas.Repository.Interface;
using System;

namespace SistemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string mySqlConnection =
               builder.Configuration.GetConnectionString("DataBase");

            builder.Services.AddDbContextPool<SistemaTarefasDBContext>(options =>
                            options.UseMySql(mySqlConnection,
                                  ServerVersion.AutoDetect(mySqlConnection)));

          //  builder.Services.AddEntityFrameworkSqlServer()
          //.AddDbContext<SistemaTarefasDBContext>(
          //   options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
          //    );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

          
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ITarefaRepository,TarefaRepository>();
            builder.Services.AddScoped<IViaCepIntegracao, ViaCepIntegracao>(); 
            builder.Services.AddRefitClient<IViaCepIntegracaoRefit>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
