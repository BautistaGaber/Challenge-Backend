using ChallengeAlkemy.Core.Repositories;
using ChallengeAlkemy.Core.Repositories.Interfaces;
using ChallengeAlkemy.Core.Services;
using ChallengeAlkemy.Core.Services.Interfaces;
using ChallengeAlkemy.Core.Users.Repositories;
using ChallengeAlkemy.Core.Users.Services;
using ChallengeAlkemy.Core.Users.Services.Interfaces;
using ChallengeAlkemy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services; 
// Add services to the container.
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<AplicationDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

services.AddScoped<IMovieRepository, MovieRepository>();
services.AddScoped<IMovieService, MovieService>();
services.AddScoped<IGenderRepository, GenderRepository>();
services.AddScoped<IGenderService, GenderService>();
services.AddScoped<ICharacterRepository, CharacterRepository>();
services.AddScoped<ICharacterServices, CharacterService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alkemy API", Version = "v1" });

    c.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
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

