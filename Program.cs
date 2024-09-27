using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using api.Middlewares;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));

// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("BusinessUnit", policy => policy.RequireRole("BusinessUnit"));
    options.AddPolicy("FAIPadmin", policy => policy.RequireRole("FAIPadmin"));
    options.AddPolicy("FAIPwarehouse", policy => policy.RequireRole("FAIPwarehouse"));
    options.AddPolicy("AdminorFAIPadmin", policy => policy.RequireRole("Admin", "FAIPadmin"));

});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Add controllers
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "BTMS_API", Version = "v1" });

   
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Bearer (jwt_token)",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BTMS_API v1"));
}
app.UseMiddleware<CustomAuthorizationMiddleware>();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
