using HtmxorExamples.Components;
using HtmxorExamples.Components.Pages.Examples.OutOfBandOutlets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ToastService>();
builder.Services.AddRazorComponents().AddHtmx(options =>
{
	// Enabled to support out of band updates
	options.UseTemplateFragments = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseHtmxAntiforgery();
app.MapRazorComponents<App>()
   .AddHtmxorComponentEndpoints(app);

app.Run();
