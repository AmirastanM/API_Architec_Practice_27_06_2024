using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CountryRepository :BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
