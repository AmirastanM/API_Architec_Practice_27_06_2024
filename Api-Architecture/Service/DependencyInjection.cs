using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;

using Service.DTOs.Admin.Countries;
using static Service.DTOs.Admin.Countries.CountryCreateDto;
using Service.Helpers;
using Service.Services.Interfaces;
using Service.Services;

namespace Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();

            services.AddScoped<ICountryService,CountryService>();
            




            return services;

        }
    }
}
