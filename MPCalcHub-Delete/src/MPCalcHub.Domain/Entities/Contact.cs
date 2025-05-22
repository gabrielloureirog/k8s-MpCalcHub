namespace MPCalcHub.Domain.Entities;

public class Contact : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int DDD { get; set; }

    public Contact() : base() { }

    public Contact(string name, string email, string password, int ddd, string phoneNumber, Guid userId) : base()
    {
        Name = name;
        Email = email;
        DDD = ddd;
        PhoneNumber = phoneNumber;

        PrepareToInsert(userId);
    }
}
