using API.Extensions;
using Domain.Constants;
using EcommerceShop.Application.Extensions;
using EcommerceShop.Domain.Entities.User;
using EcommerceShop.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Other service configurations
builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyMethod()
           .AllowAnyHeader()
           .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication(); // Ensure this is called before UseAuthorization
app.UseAuthorization();

app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.MapControllers();

app.Run();
