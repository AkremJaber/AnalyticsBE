using AnalyticsBE.Services.Implementations;
using AnalyticsBE.Services.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigurationServices(builder.Services);


// Add services to the container.


//builder.Services.Configure<appSettings>(Configuration.GetSection("appSettings"));


var app = builder.Build();
startup.Configure(app, app.Environment);

// Configure the HTTP request pipeline.

