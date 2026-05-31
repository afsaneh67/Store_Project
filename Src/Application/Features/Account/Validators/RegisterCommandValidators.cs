using Application.Features.Account.Commands.RegisterUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Account.Validators
{
    public class RegisterCommandValidators:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidators()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("لطفا شماره همراه را وارد کنید");
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("لطفا نام را وارد کنید");
            RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا رمز عبور را وارد کنید");
        }
    }
}
