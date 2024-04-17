using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RandomUser.Core.BusinessEntities;
using RandomUser.Data.DataService;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(
//this is use for Authorization
options =>
{
options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Name= "Authorization",
    Type = SecuritySchemeType.ApiKey

});
options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//this is use for Authorizatio
builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddScoped<IRandomUserBusinessEntity, RandomUserBusinessEntity>();
builder.Services.AddHttpClient<IUserDataService, UserDataService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p=>p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
