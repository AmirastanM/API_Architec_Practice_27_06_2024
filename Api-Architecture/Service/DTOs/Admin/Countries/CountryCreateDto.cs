using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Countries
{
    public class CountryCreateDto
    {
        public string Name { get; set; }


        public class CountryCreateDtoValidator : AbstractValidator<CountryCreateDto>
        {
            public CountryCreateDtoValidator()
            {
                RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            }
        }

    }
}
