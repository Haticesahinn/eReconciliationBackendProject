using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!");
            RuleFor(p => p.Name).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakterden oluşmalıdır.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş bırakılamaz!");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi yazınız.");
        }
    }
}
