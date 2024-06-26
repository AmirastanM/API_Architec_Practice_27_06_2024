using Domain.Entities;
using Service.DTOs.Admin.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAll();
        Task CreateAsync(CountryCreateDto model);
        Task<CountryDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, CountryEditDto model);
    }
}
