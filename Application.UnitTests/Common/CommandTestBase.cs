using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly TemplateDbContext _context;

        public CommandTestBase()
        {
            _context = TemplateContextFactory.Create();
        }

        public void Dispose()
        {
            TemplateContextFactory.Destroy(_context);
        }
    }
}
