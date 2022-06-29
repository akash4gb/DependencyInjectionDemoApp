using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DependencyInjectionDemo.Logic;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Everytime you ask for a item's NEW instence, add AddTransient. Most common.
builder.Services.AddTransient<IDemoLogic,AnotherDemoLogic>();

//Everytime you ask for a item's SAME instence EVERYWHARE, add AddSIngleton. most common in DesktopApp
//builder.Services.AddSingleton<DemoLogic>();

//Everytime you ask for a item's SAME instence For SAME person, add AddScoped. Most common in web
//builder.Services.AddScoped<DemoLogic>();

//Override .net default logger with Serilog.(a structured logger)
builder.Host.UseSerilog((ctx, lc) => lc
       .WriteTo.Console()
       .ReadFrom.Configuration(ctx.Configuration));

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
