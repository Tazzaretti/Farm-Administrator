using Data.Implementations;
using Data.Interfaces;
using Services.Helpers;
using Services.Implementations;
using Services.Interfaces;

namespace FarmAdministrator
{
    public class CompositeRoot
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            //SERVICES
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IPlotService, PlotService>();
            builder.Services.AddScoped<IPlantingService, PlantingService>();
            builder.Services.AddScoped<IHarvestService, HarvestService>();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            //builder.Services.AddScoped<ISubject, Subject>();

            //patron de diseno
            //builder.Services.AddScoped<IEmailNotificationObserver, EmailNotificationObserver>();

            //REPOSITORIES
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlotRepository, PlotRepository>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IHarvestRepository, HarvestRepository>();
            builder.Services.AddScoped<IPlantingRepository, PlantingRepository>();
            //builder.Services.AddScoped<ISuscriptorRepository, SuscriptorRepository>();


            //Helpers
            builder.Services.AddScoped<GenerateToken>();
            builder.Services.AddScoped<IEncryptHelper, EncryptHelper>();



        }
    }
}
