using Microsoft.EntityFrameworkCore;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Services;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Context;
using SLM.User.Infrastructure.Persistence.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "User Managment Api's Version 1",
        //Description = "Your API Description",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Devkranth Kishore Vanja",
            Email = "Devkranth@gmail.com",
            Url = new Uri("https://example.com"),
        }
    });
   
    //c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Version = "v2",
    //    Title = "API V2",
    //    // Add other info for v2
    //});
});

builder.Services.AddTransient<IUserEntityRepository, UserEntityRepository>();
builder.Services.AddTransient<IUserCredentialsEntityRepostiory, UserCredentialsEntityRepository>();
builder.Services.AddTransient<IDesignationEntityRepository, DesignationEntityRepository>();
builder.Services.AddTransient<IUserTypeEntityRepository, UserTypeEntityRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddDbContext<UserManagementContext>(options =>
{
    //the change occurs here.
    //builder.cofiguration and not just configuration
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDBConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Managment Api's Version 1");
        //c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();