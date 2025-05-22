using System.Text.Json;
using AutoMapper;
using MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Application.Interfaces;
using MPCalcHub.Domain.Constants;
using MPCalcHub.Domain.Interfaces;
using EN = MPCalcHub.Domain.Entities;
using MSG = MPCalcHub.Application.DataTransferObjects.MessageBrokers;

namespace MPCalcHub.Application.Services;

public class ContactApplicationService(IContactService contactService, IMapper mapper) : IContactApplicationService
{
    private readonly IContactService _contactService = contactService;
    private readonly IMapper _mapper = mapper;

    public async Task Remove(Guid id)
    {
        await _contactService.Remove(id);
    }

    public async Task Consumer(string message, string rountingKey)
    {
        switch(rountingKey)
        {
            case AppConstants.Routes.RabbitMQ.ContactRemoved:
                var contactRemoved = JsonSerializer.Deserialize<MSG.Identifier>(message);
                await Remove(contactRemoved.Id);
                break;
        }
    }

    public void Dispose()
    {
        _contactService.Dispose();

        GC.SuppressFinalize(this);
    }
}
