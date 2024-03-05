using App.Application.Features.CountryFeatures.Commands;
using App.Domain.Entities;
using App.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace App.Test.Application
{
    public class CreateCountryCommandTests
    {
        [Fact]
        public async Task Handle_ValidCommand_AddsCountryToDbContext()
        {
            // Arrange
            var dbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>(), (new Mock<IMediator>()).Object);
            dbContextMock.Setup(db => db.Countries.Add(It.IsAny<Country>()));

            var handler = new CreateCountryCommandHandler(dbContextMock.Object);

            var command = new CreateCountryCommand("TestCountry", "English", 1000000);

            // Act
            var countryId = await handler.Handle(command, CancellationToken.None);

            // Assert
            dbContextMock.Verify(db => db.Countries.Add(It.IsAny<Country>()), Times.Once);
            dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
