using Microsoft.EntityFrameworkCore;
using WebAPITutorial.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

      //***configuring sql server after AddControllers but before builder.Build***
     builder.Services.AddDbContext<AppDbContext>(x =>
     {
          string ConnectionKey = "Dev";
#if RELEASE
          ConnectionKey = "Prod";
#endif

          x.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionKey));
     });

        builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

      //***added the below - not what you want to actually do in production.
        app.UseCors(x =>
        {
            x.AllowAnyOrigin()  //chaining together
            .AllowAnyHeader()
            .AllowAnyMethod();
        });

app.UseAuthorization();

app.MapControllers();

        //optional -statements to auto update database.
        //web hosting might restrict access to update sql database from home.
            //creating a scope to use in the next line. Applying migration that has not been applied already.
        using var scope = app.Services
                            .GetRequiredService<IServiceScopeFactory>()
                            .CreateScope();
        scope.ServiceProvider
                    .GetService<AppDbContext>()!
                    .Database.Migrate();


app.Run();
