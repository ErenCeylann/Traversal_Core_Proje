using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını Giriniz");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Lütfen Rehber Görselini Giriniz");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha az bir değer giriniz");
            RuleFor(x=>x.Name).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla bir değer giriniz");

        }
    }
}
