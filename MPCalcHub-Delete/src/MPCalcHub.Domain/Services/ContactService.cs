using System.ComponentModel.DataAnnotations;
using MPCalcHub.Domain.Entities;
using MPCalcHub.Domain.Interfaces;
using MPCalcHub.Domain.Interfaces.Infrastructure;

namespace MPCalcHub.Domain.Services;

public class ContactService(IContactRepository contactRepository, UserData userData, IStateDDDService stateDDDService) : BaseService<Contact>(contactRepository, userData), IContactService
{
    private readonly IContactRepository _contactRepository = contactRepository;
    private readonly IStateDDDService _stateDDDService = stateDDDService;

    public async Task<Contact> GetById(Guid id, bool include, bool tracking)
    {
        var entity = await _contactRepository.GetById(id, include, tracking);

        if (entity == null)
            throw new ValidationException("O contato não existe.");

        return entity;
    }

    public async Task Remove(Guid id)
    {
        var entity = await _contactRepository.GetById(id, false, true);
        if (entity == null)
            throw new Exception("O contato não existe.");

        await base.Remove(entity);
    }
}