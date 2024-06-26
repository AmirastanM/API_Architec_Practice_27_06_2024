using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryEditDto, Country>();
        }
    }
}
