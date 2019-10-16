using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Domain.Entities;
using MediatR;

namespace Application.TemplateFeature.Commands
{
    public class CreateTemplateEntityCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class CreateTemplateEntityCommandHandler : IRequestHandler<CreateTemplateEntityCommand>
    {
        private readonly ITemplateDbContext _context;

        public CreateTemplateEntityCommandHandler(ITemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTemplateEntityCommand request, CancellationToken cancellationToken)
        {
            _context.TemplateEntities.Add(new TemplateEntity()
            {
                Name = request.Name
            });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
