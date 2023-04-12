﻿using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.App.Application.Command;
using Order.App.Services;
using Order.App.Settings;
using Order.Infrastructure;

namespace Order.App.Extensions;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKafkaConsumer();
        services.AddDbContext(configuration);
        services.AddMediator();
        services.AddSendMail(configuration);
        return services;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddSingleton<DbContextModel>();
        services.AddDbContext<DbContextModel>(options =>
        {
            options.UseOracle(configuration.GetConnectionString("OraDbConnection"));
        });
        return services;
    }
    public static IServiceCollection AddSendMail(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddTransient<IMailService, Services.MailService>();
        return services;
    }
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(OrderCommand));
        return services;
    }

    public static IServiceCollection AddKafkaConsumer(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "group2",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = true,
            };
            return new ConsumerBuilder<string, string>(consumerConfig).Build();
        });

        return services;

    }
}