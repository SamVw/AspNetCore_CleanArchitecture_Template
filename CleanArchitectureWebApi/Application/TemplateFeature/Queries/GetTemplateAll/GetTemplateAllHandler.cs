using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.TemplateFeature.Queries.GetTemplateAll
{
    public class GetTemplateAllHandler : IRequestHandler<GetTemplateAllQuery, TemplateAllVm>
    {
        public async Task<TemplateAllVm> Handle(GetTemplateAllQuery request, CancellationToken cancellationToken)
        {
            return new TemplateAllVm();
        }
    }
}
