using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(c => c.StarCount).InclusiveBetween(0, 5);
            RuleFor(c => c.StarCount).GreaterThan(0).WithMessage("Ürün fiyatı 0 olamaz");
            RuleFor(c => c.CommentDescription).MaximumLength(500);
        }
    }
}
