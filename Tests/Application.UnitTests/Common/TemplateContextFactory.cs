using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UnitTests.Common
{
    public class TemplateContextFactory
    {
        public static TemplateDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TemplateDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new TemplateDbContext(options);

            context.Database.EnsureCreated();

            context.TemplateEntities.AddRange(new[] {
                new TemplateEntity {  Id = 1, Name = "Test1"},
                new TemplateEntity {  Id = 2, Name = "Test2"},
                new TemplateEntity {  Id = 3, Name = "Test3"},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(TemplateDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
