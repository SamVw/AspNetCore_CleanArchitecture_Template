using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Persistence
{
    public class TemplateDbContext : DbContext, ITemplateDbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }

        public DbSet<TemplateEntity> TemplateEntities { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override DatabaseFacade Database => base.Database;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TemplateDbContext).Assembly);
        }
    }
}
