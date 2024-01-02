using Microsoft.EntityFrameworkCore;
using SimpleCalculator.ActionHandlers;
using SimpleCalculator.Data;
using SimpleCalculator.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// We want to use EF core and add into the project
// We have to tell which class has the db context implementation  
// We want to tell EF that our db context is using sql server
// Add connection string from appsettings.json using the builder.Configuration 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    try
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    catch (Exception ex)
    {

        Console.WriteLine("Error connecting to the database: " + ex.Message);
    }
});*/




// AddScoped is new for each request
builder.Services.AddScoped<IActionHandler, ActionHandler>();


var app = builder.Build();







// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
