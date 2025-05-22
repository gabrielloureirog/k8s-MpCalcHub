using Bogus;
using MPCalcHub.Domain.Entities;
using MPCalcHub.Tests.Shared.Fixtures.Utils;

namespace MPCalcHub.Tests.Shared.Fixtures.Entities;

public sealed class ContactFixtures : BaseFixtures<Contact>
{   
    public static Contact GenerateContact()
    {
        var faker = new Faker<Contact>("pt_BR")
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.DDD, f => f.Random.Int(10, 99))
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("#########"));

        return faker.Generate();
    }

    public static Contact CreateAs_Base()
    {
        var faker = new Faker<Contact>("pt_BR")
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.DDD, f => f.Random.Int(10, 99))
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("#########"));

        var contact = faker.Generate();
        contact.PrepareToInsert(Guid.NewGuid());

        return contact;
    }
}