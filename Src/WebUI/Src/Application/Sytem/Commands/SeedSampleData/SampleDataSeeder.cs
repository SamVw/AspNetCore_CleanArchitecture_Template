using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Sytem.Commands.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly ITemplateDbContext _context;

        public SampleDataSeeder(ITemplateDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.TemplateEntities.Any())
            {
                return;
            }

            await SeedTemplateEntitiesAsync(cancellationToken);
        }

        private async Task SeedTemplateEntitiesAsync(CancellationToken cancellationToken)
        {
            var templateEntities = new[]
            {
                new TemplateEntity { Name = "test1" },
                new TemplateEntity { Name = "test2" },
                new TemplateEntity { Name = "test3" }
            };

            await _context.TemplateEntities.AddRangeAsync(templateEntities, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
