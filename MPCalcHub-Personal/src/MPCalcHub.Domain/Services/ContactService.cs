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

    public override async Task<Contact> Add(Contact entity)
    {
        var contact = await _contactRepository.GetById(entity.Id);

        if (contact != null)
            throw new ValidationException("O contato já existe.");

        var existsDDD = await _stateDDDService.GetByDDDAsync(entity.DDD);
        if (existsDDD == null)
            throw new ValidationException("DDD inválido e/ou não existe.");
        
        return await base.Add(entity);
    }

    public override async Task<Contact> Update(Contact entity)
    {
        var existsDDD = await _stateDDDService.GetByDDDAsync(entity.DDD);
        if (existsDDD == null)
            throw new ValidationException("DDD inválido e/ou não existe.");

        return await base.Update(entity);
    }

    public async Task<Contact> GetByEmail(string email)
    {
        var entity = await _contactRepository.GetByEmail(email);
        if (entity == null)
            throw new Exception("O contato não existe.");

        return entity; 
    }

    public async Task Remove(Guid id)
    {
        var entity = await _contactRepository.GetById(id, false, true);
        if (entity == null)
            throw new Exception("O contato não existe.");

        await base.Remove(entity);
    }

    public async Task<IEnumerable<Contact>> FindByDDD(int ddd)
    {
        return await _contactRepository.FindBy(ddd);
    }
}