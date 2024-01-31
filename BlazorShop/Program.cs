using BlazorShop.Data;
using BlazorShop.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Text;


Console.OutputEncoding = Encoding.UTF8;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddScoped<NowTime>();

builder.Services.AddTransient<IClock, NowTime>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProductRepository, InDbSQLiteCatalog>();             //      InMemoryCatalog>();  InDbSQLiteCatalog                          


var dbPath = "BlazorShopDb.db";
builder.Services.AddDbContext<AppDbContext>(
   options => options.UseSqlite($"Data Source={dbPath}"));

// реализация через IOptions

builder.Services.AddOptions<SmtpEmailSenderOptions>()
   .BindConfiguration("SmtpConfig")
   .ValidateDataAnnotations()
   .ValidateOnStart();

builder.Services.AddScoped<ISmtpMailSender, SmtpMailSender>();


builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
