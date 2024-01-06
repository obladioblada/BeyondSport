using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo {
            Version = "pre-hiring",
            Title = "Player",
            Description = "Get your player data",
        });
        // using System.Reflection;
         var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
         options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
    }
);
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
