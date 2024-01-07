using System.Reflection;
using beyondsports.dbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddScoped<DbContext, BeyondSportContext>();

builder.Services.AddDbContext<BeyondSportContext>(options => 
 options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    new MySqlServerVersion(new Version(8, 0, 22))
    )
);

builder.Services.AddControllers();
builder.Services.AddMvcCore().AddDataAnnotations();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
