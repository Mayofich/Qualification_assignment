using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Qualification_API_Blazor.Data;
using Dapper;
using Syncfusion.Blazor;
using Qualification_API_Blazor.Services;
using Qualification_API_Blazor.Adapters;

DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IStrojService, StrojService>();
builder.Services.AddScoped<StrojAdapter>();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});



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
