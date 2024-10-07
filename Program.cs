using Microsoft.AspNetCore.Routing.Constraints;
using TeamDev360.Components;
using TeamDev360.Models;
using TeamDev360.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();
// Registers all handlers in this assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddSingleton<ComponentState>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<TicketMasterService>();
builder.Services.AddTransient<Event>();
// Register the configuration class and bind the configuration section
builder.Services.Configure<TicketMasterConfig>(builder.Configuration.GetSection("TicketMasterConfig"));
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("string", typeof(StringRouteConstraint));
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
