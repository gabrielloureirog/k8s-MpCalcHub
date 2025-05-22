using Bogus;
using MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Tests.Shared.Fixtures.Utils;

namespace MPCalcHub.Tests.Shared.Fixtures.DataTransferObjects;

public sealed class BasicContactFixtures : BaseFixtures<BasicContact>
{
    public BasicContactFixtures() : base() { }

    public static BasicContact GenerateUser()
    {
        var faker = Faker
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber("#########"))
            .RuleFor(u => u.DDD, f => f.Random.Int(10, 99));

        return faker.Generate();
    }

    public static BasicContact CreateAs_Base()
    {
        var contact = GenerateUser();

        return contact;
    }

    public static BasicContact CreateAs_InvalidName()
    {
        var contact = CreateAs_Base();
        contact.Name = string.Empty;

        return contact;
    }

    public static BasicContact CreateAs_InvalidEmail()
    {
        var contact = CreateAs_Base();
        contact.Email = FakerDefault.Random.String2(2, 2);

        return contact;
    }

    public static BasicContact CreateAs_InvalidPhoneNumber()
    {
        var contact = CreateAs_Base();
        contact.PhoneNumber = FakerDefault.Random.String2(2, 2);

        return contact;
    }

    public static BasicContact CreateAs_InvalidDDD()
    {
        var contact = CreateAs_Base();
        contact.DDD = FakerDefault.Random.Int(2, 2);

        return contact;
    }
}