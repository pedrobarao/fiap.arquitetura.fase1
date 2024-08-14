﻿using System.Diagnostics.CodeAnalysis;
using Fase1.Contatos.Application.UseCases;
using Fase1.Contatos.Application.UseCases.Interfaces;
using Fase1.Contatos.Domain.Repositories;
using Fase1.Contatos.Infra.Data;
using Fase1.Contatos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fase1.Contatos.Api.Config;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApplicationServices(services);
        RegisterDomainServices(services);
        RegisterInfraServices(services, configuration);

        return services;
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        services.AddScoped<ICadastrarContatoUseCase, CadastrarContatoUseCase>();
        services.AddScoped<IObterContatoUseCase, ObterContatoUseCase>();
        services.AddScoped<IListarContatoUseCase, ListarContatoUseCase>();
        services.AddScoped<IExcluirContatoUseCase, ExcluirContatoUseCase>();
        services.AddScoped<IAtualizarContatoUseCase, AtualizarContatoUseCase>();
    }

    private static void RegisterDomainServices(IServiceCollection services)
    {
        services.AddScoped<IContatoRepository, ContatoRepository>();
    }

    private static void RegisterInfraServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContatoDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}