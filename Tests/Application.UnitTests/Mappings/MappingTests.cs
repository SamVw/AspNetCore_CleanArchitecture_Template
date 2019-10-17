using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.TemplateFeature.Queries.GetTemplateAll;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapTemplateEntityToTemplateDto()
        {
            var entity = new TemplateEntity();

            var result = _mapper.Map<TemplateDto>(entity);

            result.Should().NotBeNull();
            result.Should().BeOfType<TemplateDto>();
        }
    }
}
