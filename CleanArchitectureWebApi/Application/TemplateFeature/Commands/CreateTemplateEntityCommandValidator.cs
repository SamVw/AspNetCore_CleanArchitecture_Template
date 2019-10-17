using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.TemplateFeature.Commands
{
    public class CreateTemplateEntityCommandValidator : AbstractValidator<CreateTemplateEntityCommand>
    {
        public CreateTemplateEntityCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(60);
        }
    }
}
