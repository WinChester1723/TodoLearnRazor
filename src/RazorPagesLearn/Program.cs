using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesLearn.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesLearnContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesLearnContext") 
    ?? throw new InvalidOperationException("Connection string 'RazorPagesLearnContext' not found.")));
}
else
{
    builder.Services.AddDbContext<RazorPagesLearnContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesLearnContext") 
    ?? throw new InvalidOperationException("Connection string 'RazorPagesLearnContext' not found.")));
}

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
