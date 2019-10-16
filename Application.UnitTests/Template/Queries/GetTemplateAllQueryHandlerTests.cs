using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.TemplateFeature.Queries;
using Application.TemplateFeature.Queries.GetTemplateAll;
using Application.UnitTests.Common;
using AutoMapper;
using FluentAssertions;
using Persistence;
using Xunit;

namespace Application.UnitTests.Template.Queries
{
    [Collection("QueryCollection")]
    public class GetTemplateAllQueryHandlerTests
    {
        private readonly TemplateDbContext _context;
        private readonly IMapper _mapper;

        public GetTemplateAllQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTemplateAllTest()
        {
            var sut = new GetTemplateAllQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetTemplateAllQuery(), CancellationToken.None);

            result.Should().BeOfType<TemplateAllVm>();
            result.Should().NotBeNull();
            result.Templates.Count.Should().Be(_context.TemplateEntities.Count());
        }
    }
}
