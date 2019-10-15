using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ITemplateDbContext
    {
        DbSet<TemplateEntity> TemplateEntities { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
