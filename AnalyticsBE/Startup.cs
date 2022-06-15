using AnalyticsBE.Services.Implementations;
using AnalyticsBE.Services.Interfaces;
using Microsoft.Identity.Web;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigurationServices(IServiceCollection services)
    {
        services.AddMicrosoftIdentityWebAppAuthentication(Configuration, "ServicePrincipalApp")
          .EnableTokenAcquisitionToCallDownstreamApi()
          .AddInMemoryTokenCaches();
        //services.AddHttpClient();
        services.AddControllers();
        services.AddScoped<IPowerBIModelService, PowerBIModelImpl>();
        //services.AddTransient<Microsoft.Identity.Web.ITokenAcquisition, tokenAcquisition>();

        //builder.Services.AddSingleton<IPowerBIModelService, PowerBIModelImpl>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers().AddJsonOptions(options => {
            options.JsonSerializerOptions.IncludeFields = true;
        });
    }
    public void Configure(WebApplication app,IWebHostEnvironment env)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();


        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });

        app.Run();
    }
}

