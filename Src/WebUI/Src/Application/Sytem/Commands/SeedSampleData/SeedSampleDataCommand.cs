using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Sytem.Commands.SeedSampleData
{

    public class SeedSampleDataCommand : IRequest
    {
        
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ITemplateDbContext _context;

        public SeedSampleDataCommandHandler(ITemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
