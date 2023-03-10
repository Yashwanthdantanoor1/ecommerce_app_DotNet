using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddScoped<ICinemasService, CinemasService>();*/
builder.Services.AddScoped<IActorsService, ActorsService>();
/*builder.Services.AddScoped<IProducerService, ProducerService>();*/

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddControllersWithViews();

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
	pattern: "{controller=Movies}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);

app.Run();
