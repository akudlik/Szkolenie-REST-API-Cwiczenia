using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace CwiczeniaRESTAPI.Infrastructure.Migration
{
      /// <summary>
    /// Migration Service
    /// </summary>
    public class MigrationService 
    {
        private readonly string _connectionString;

        private static object _lockObj = new object();

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="connectionString">SQL Connection string</param>
        public MigrationService(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Run migration
        /// </summary>
        public void Migrate()
        {
            lock (_lockObj)
            {
                var serviceProvider = CreateServices();

                // Put the database update into a scope to ensure
                // that all resources will be disposed.
                using (var scope = serviceProvider.CreateScope())
                {
                    UpdateDatabase(scope.ServiceProvider);
                }
            }
        }

        private IServiceProvider CreateServices()
        {

            return new ServiceCollection()
                .AddFluentMigratorCore() // Add common FluentMigrator services
                .ConfigureRunner(rb => rb
                    .AddSqlServer2014() // Add SQL support to FluentMigrator
                    .WithGlobalConnectionString(_connectionString) // Set the connection string
                    .ScanIn(typeof(MigrationService).Assembly).For.Migrations()) // Define the assembly containing the 
                .AddLogging(lb => lb.AddFluentMigratorConsole()) // Enable logging to console in the FluentMigrator 
                .BuildServiceProvider(false); // Build the service provider
        }

        private void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
