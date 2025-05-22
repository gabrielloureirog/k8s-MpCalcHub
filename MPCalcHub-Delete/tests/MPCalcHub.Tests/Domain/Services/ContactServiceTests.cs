using System.ComponentModel.DataAnnotations;
using MPCalcHub.Domain.Entities;
using MPCalcHub.Domain.Interfaces;
using MPCalcHub.Domain.Interfaces.Infrastructure;
using MPCalcHub.Domain.Services;
using MPCalcHub.Infrastructure.Data.Repositories;
using MPCalcHub.Tests.Shared.Fixtures;
using MPCalcHub.Tests.Shared.Fixtures.Entities;
using MPCalcHub.Tests.Shared.Fixtures.Utils;

namespace MPCalcHub.Tests.Domain.Services;

public class ContactServiceTests : BaseServiceTests
{
    private readonly IContactRepository _repository;
    private readonly IContactService _contactService;
    private readonly IStateDDDService _stateDDDService;
    private readonly IStateDDDRepository _stateDDDRepository;
    private readonly UserData _userData;

    public ContactServiceTests()
    {
        _userData = UserDataFixtures.CreateAs_Base();
        _repository = new ContactRepository(_context);
        _stateDDDRepository = new StateDDDRepository(_context);
        _stateDDDService = new StateDDDService(_stateDDDRepository, _userData);
        _contactService = new ContactService(_repository, _userData, _stateDDDService);
    }

    public class Remove : ContactServiceTests
    {
        [Fact]
        public async Task ShouldRemoveContact()
        {
            // Arrange
            var contact = ContactFixtures.CreateAs_Base();
            await _context.AddAsync(contact);
            await SaveChanges();

            // Act
            await _contactService.Remove(contact.Id);
            await SaveChanges();

            // Assert
            var exception = await Assert.ThrowsAsync<ValidationException>(async () => await _contactService.GetById(contact.Id, false, false));

            Assert.Equal("O contato não existe.", exception.Message);
            Assert.True(contact.Removed);
        }
    }

    public override void Dispose()
    {
        _context?.Dispose();
        _contactService?.Dispose();
        _repository?.Dispose();
        
        GC.SuppressFinalize(this);
    }
}