using Microsoft.EntityFrameworkCore;
using FunShield.Models;
using FunShield.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<FunShieldDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("FunShieldConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SeedData.Initialize(scope.ServiceProvider);
}

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
