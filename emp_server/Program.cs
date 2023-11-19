using emp_server.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// Inside ConfigureServices method in Startup.cs
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("contactsDB"));
builder.Services.AddDbContext<ProductsAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("emp_server_connectionString")));
//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//options.DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"));

//});
//System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
//System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyOrigin()
            .AllowAnyHeader();
        });
});
var app = builder.Build();
//var cultureInfo = new CultureInfo("en-US");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
