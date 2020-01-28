using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.Infrastructure.Migration;
using CwiczeniaRESTAPI.Infrastructure.Repositories;
using CwiczeniaRESTAPI.Infrastructure.Repositories.InMemory;
using CwiczeniaRESTAPI.Infrastructure.UnitOfWorks;
using CwiczeniaRESTAPI.SeedWork;
using CwiczeniaRESTAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Util;

namespace CwiczeniaRESTAPI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Register DI
        /// </summary>
        private void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<ITransactionUnitOfWork>(s => new NHibernateUnitOfWork(Configuration["ConnectionString"]));

            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IMedicalReportService, MedicalReportService>();

            if (false)
            {
                services.AddTransient<IPatientRepository, PatientRepositoryInMemory>();
                services.AddTransient<IDoctorRepository, DoctorRepositoryInMemory>();
                services.AddTransient<IMedicalReportRepository, MedicalReportRepositoryInMemory>();

                return;
            }
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IMedicalReportRepository, MedicalReportRepository>();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            InitializeAutoMapper();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //FluentMigrator
            var migrationService = new MigrationService(Configuration["ConnectionString"]);
            migrationService.Migrate();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        
        private void InitializeAutoMapper()
        {
            var profileType = typeof(Profile);
            // Get an instance of each Profile in the executing assembly.
            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(types => profileType.IsAssignableFrom(types)
                                && types.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            // Initialize AutoMapper with each instance of the profiles found.
            Mapper.Initialize(mapper => profiles.ForEach(mapper.AddProfile));
        }

    }
}