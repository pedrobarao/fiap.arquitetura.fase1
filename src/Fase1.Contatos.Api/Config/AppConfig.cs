using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Fase1.Contatos.Api.Config;

[ExcludeFromCodeCoverage]
public static class AppConfig
{
    public static IServiceCollection AddAppConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerConfig();

        services.RegisterServices(configuration);

        return services;
    }

    public static WebApplication UseAppConfig(this WebApplication app)
    {
        app.UseSwaggerConfig();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}