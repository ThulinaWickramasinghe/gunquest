global using RPG.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RPG.Data;
using RPG.Services.CharacterService;
using RPG.Services.FightService;
using RPG.Services.WeaponService;
using Swashbuckle.AspNetCore.Filters;

 // create an instance of WebApplicationBuilder class with command line arguments
var builder = WebApplication.CreateBuilder(args); 
 
// Add data base connection for SQL server
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services for controllers
builder.Services.AddControllers();

// Add support for Minimal API's
builder.Services.AddEndpointsApiExplorer();

// Add swagger services
builder.Services.AddSwaggerGen(
    c =>
    {
        c.AddSecurityDefinition("oauth2",
        new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme, e.g. \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        c.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)
            ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
);

builder.Services.AddHttpContextAccessor();

//register WeaponService with a scoped lifetime
builder.Services.AddScoped<IWeaponService, WeaponService>();

//register FightService service with a scoped lifetime
builder.Services.AddScoped<IFightService, FightService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
