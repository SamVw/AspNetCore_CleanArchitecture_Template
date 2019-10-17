using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.TemplateFeature.Commands;
using Application.UnitTests.Common;
using FluentAssertions;
using MediatR;
using Moq;
using Persistence;
using Xunit;

namespace Application.UnitTests.Template.Commands
{
    public class CreateTemplateEntityCommandTests : CommandTestBase
    {

        [Fact]
        public async Task ShouldCreateNewTemplateEntity()
        {
            var sut = new CreateTemplateEntityCommandHandler(_context);

            var result = await sut.Handle(new CreateTemplateEntityCommand() {Name = "new template entity"}, CancellationToken.None);
            
            var newTemplate = _context.TemplateEntities.FirstOrDefault(t => t.Name == "new template entity");
            newTemplate.Should().NotBeNull("Template should be added to context");
            newTemplate?.Name.Should().Be("new template entity", "that's the assigned name of the new template entity");
        }

        [Fact]
        public async Task ShouldThrowBadRequestErrorIfDuplicate()
        {
            var sut = new CreateTemplateEntityCommandHandler(_context);

            await sut.Handle(new CreateTemplateEntityCommand() { Name = "duplicate name" }, CancellationToken.None);

             await Assert.ThrowsAsync<BadRequestException>(() => sut.Handle(
                    new CreateTemplateEntityCommand()
                    {
                        Name = "duplicate name"
                    }, CancellationToken.None));
        }
    }
}
