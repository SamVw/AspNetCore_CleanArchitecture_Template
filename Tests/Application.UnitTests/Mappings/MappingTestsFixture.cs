using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;

namespace Application.UnitTests.Mappings
{
    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}
