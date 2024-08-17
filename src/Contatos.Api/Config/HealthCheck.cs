using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Contatos.Api.Config;

public static class HealthCheckConfig
{
    private const string livenessTag = "live";
    private const string readinessTag = "ready";

    public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck("Liveness", () => HealthCheckResult.Healthy(), new[] { livenessTag });

        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DefaultConnection"),
                failureStatus: HealthStatus.Unhealthy,
                tags: [readinessTag]);

        return services;
    }

    public static WebApplication UseHealthCheck(this WebApplication app)
    {
        app.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            Predicate = check => check.Tags.Contains(livenessTag)
        });

        app.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            Predicate = check => check.Tags.Contains(readinessTag)
        });

        app.MapHealthChecksUI();

        return app;
    }
}