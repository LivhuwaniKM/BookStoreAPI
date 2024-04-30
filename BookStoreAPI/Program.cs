using BSCore;
using BSRepositories;
using BSServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BookStoreDbContext");

builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseSqlServer(connectionString, c => c.MigrationsAssembly("BookStore"));
});

//builder.Services.AddEndpointsApiExplorer();       research

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RESTful API", Version = "v1" });
});

builder.Services.AddControllers();

builder.Services.AddSession();

/*builder.Services.AddDistributedMemoryCache();       // research*/

builder.Services.AddMvc();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<JWTAuth>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    JWTAuth jwtObject = new();
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["baseurl:Issuer"],
        ValidAudience = builder.Configuration["baseurl:Audience"],
        IssuerSigningKey = jwtObject.GetSigningKey,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30)
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BookStoreDbContext>();
    context.Database.Migrate();
}

app.UseSession();

app.Use(async (context, next) =>
{
    var token = context.Session.GetString("SecurityToken");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Append("Authorization", $"Bearer {token}");
    }
    await next();
});

// app.UseHttpsRedirection();       research

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "EntityFramework.MySQL");
    c.RoutePrefix = "";
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();