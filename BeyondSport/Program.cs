using System.Reflection;
using beyondsports.dbContext;
using beyondsports.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddMvcCore().AddDataAnnotations();
    builder.Configuration.AddEnvironmentVariables();
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
    if (builder.Environment.IsDevelopment())
    {
        Console.WriteLine("Since running in Development, in-memory DataBase will be used.");
        builder.Services.AddDbContext<ApplicationContext>(
            options =>  options.UseInMemoryDatabase(databaseName: "beyondSportsDB")
        );
        
    } else {
        Console.WriteLine("NOT running in Development, MySql DataBase will be used.");
        builder.Services.AddDbContext<ApplicationContext>(
            options => options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"), 
                new MySqlServerVersion(new Version(8, 0, 22)), 
                options => options.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null)
            )
        );
    }
    builder.Services.AddScoped<ApplicationContext>();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();

    if (app.Environment.IsDevelopment()) {
        using var scope = app.Services.CreateScope();
        ApplicationContext context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        Console.WriteLine("Seeding for local development");
        ISeeder seeder = new InMemorySeeder(context);
        seeder.Seed();
        Console.WriteLine("Seeding for local development finished");
    }
}

app.Run();


// needed for Testing

public partial class Program { }