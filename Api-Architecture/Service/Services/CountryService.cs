using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper,ICountryRepository countryRepo)
        {

            _mapper = mapper;
            _countryRepo = countryRepo;
            
        }
        public async Task CreateAsync(CountryCreateDto model)
        {
            if(model == null) throw new ArgumentNullException();
           await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _countryRepo.GetById(id);
            await _countryRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _countryRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _countryRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
           
           var countries = await _countryRepo.GetAllAsync();
           return _mapper.Map<IEnumerable<CountryDto>>(countries);
         
        } 

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CountryDto>(await _countryRepo.GetById(id));
        }
    }
}
