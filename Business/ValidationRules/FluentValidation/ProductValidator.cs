﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).MinimumLength(5);       
            RuleFor(p => p.Name).NotEmpty();

            RuleFor(p => p.Description).MinimumLength(15);
            RuleFor(p => p.Description).MaximumLength(250);
            RuleFor(p => p.Description).NotEmpty();


        }
    }
}
