using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz");

            //RuleFor(u => u.)
            //   .NotEmpty()
            //   .MinimumLength(8)
            //   .Matches("[A-Z]").WithMessage("Bir büyük karakter içermelidir.")
            //   .Matches("[a-z]").WithMessage("Bir küçük karakter içermelidir.")
            //   .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Bir özel karakter içermelidir.");
        }
    }
}
