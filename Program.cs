using TestApplication.Models;
using TestApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Services = builder.Services;
Services.AddRazorPages();
Services.AddTransient<JsonFileProductService>();
Services.AddControllers();
Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    //app.UseExceptionHandler("/Invalid");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Error");
}

// Maps.
app.MapControllers();
app.MapBlazorHub();
app.MapRazorPages();

// Uses.
app.UseStatusCodePagesWithReExecute("/Invalid");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Run.
app.Run();
