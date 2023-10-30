using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Neuronix.Core.IServices;
using Neuronix.Data;
using Neuronix.Services;

var builder = WebApplication.CreateBuilder(args);

var sqlString = builder.Configuration.GetConnectionString("SqlConnection");

Console.Write("[INFO]\tConnection String: ");
Console.WriteLine(sqlString);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Services
builder.Services.AddTransient<IAssignmentService, AssignmentService>();

// Add DataContext
builder.Services.AddDbContext<DataContext>(options => options.UseMySql(sqlString, ServerVersion.AutoDetect(sqlString)));
/*builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DataContext>();*/

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