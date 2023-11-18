using GeekLifeAPI.Data.CategoriaRepository;
using GeekLifeAPI.Data.CDRepository;
using GeekLifeAPI.Data.EfCore;
using GeekLifeAPI.Data.ProdutoRepository;
using GeekLifeAPI.Data.SubRepository;
using GeekLifeAPI.Integracao;
using GeekLifeAPI.Integracao.Interfaces;
using GeekLifeAPI.Integracao.Refit;
using GeekLifeAPI.Service.SubService;
using GeekLifeAPI.Services.CategoriaService;
using GeekLifeAPI.Services.CDService;
using GeekLifeAPI.Services.ProdutoService;
using GeekLifeAPI.Services.SubService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Refit;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CategoriaConnection");

builder.Services.AddDbContext<CategoriaContext>(opts => opts.UseLazyLoadingProxies().UseMySql(connectionString,
 ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //<< Adicionando Auto-Mapper
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<ISubRepository, SubRepository>();
builder.Services.AddTransient<ISubService, SubService>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<ICDRepository, CDRepository>();
builder.Services.AddTransient<ICDService, CDService>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<SubRepository>();
builder.Services.AddScoped<SubService>();
builder.Services.AddScoped<CDService>();
builder.Services.AddScoped<CDRepository>();


builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekLifeAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(c =>
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

