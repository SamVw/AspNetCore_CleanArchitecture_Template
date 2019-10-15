using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;

namespace Application.TemplateFeature.Queries.GetTemplateAll
{
    public class GetTemplateAllHandler : IRequestHandler<GetTemplateAllQuery, TemplateAllVm>
    {
        private readonly ITemplateDbContext _context;

        public GetTemplateAllHandler(ITemplateDbContext context)
        {
            _context = context;
        }

        public async Task<TemplateAllVm> Handle(GetTemplateAllQuery request, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(CancellationToken.None);
            return new TemplateAllVm();
        }
    }
}
