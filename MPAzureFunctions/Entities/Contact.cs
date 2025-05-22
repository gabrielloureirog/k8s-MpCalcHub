namespace MPAzureFunctions.Entities;

public class Contact
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required int DDD { get; set; }
    public required string PhoneNumber { get; set; }
}