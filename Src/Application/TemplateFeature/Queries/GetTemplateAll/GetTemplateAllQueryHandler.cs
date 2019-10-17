using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TemplateFeature.Queries.GetTemplateAll
{
    public class GetTemplateAllQueryHandler : IRequestHandler<GetTemplateAllQuery, TemplateAllVm>
    {
        private readonly ITemplateDbContext _context;
        private readonly IMapper _mapper;

        public GetTemplateAllQueryHandler(ITemplateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateAllVm> Handle(GetTemplateAllQuery request, CancellationToken cancellationToken)
        {
            var templates = await _context.TemplateEntities.ProjectTo<TemplateDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new TemplateAllVm() { Templates = templates };
        }
    }
}
