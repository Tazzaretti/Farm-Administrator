﻿using Data.Implementations;
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
            //builder.Services.AddScoped<ISubject, Subject>();

            //patron de diseno
            //builder.Services.AddScoped<IEmailNotificationObserver, EmailNotificationObserver>();

            //REPOSITORIES
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            //builder.Services.AddScoped<ISuscriptorRepository, SuscriptorRepository>();


            //Helpers
            builder.Services.AddScoped<GenerateToken>();
            builder.Services.AddScoped<IEncryptHelper, EncryptHelper>();



        }
    }
}