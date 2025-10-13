namespace Ordering.Orders.ValueObjects;

public record Address
{
    public string State { get; } = default!;
    public string Country { get; } = default!;
    public string ZipCode { get; } = default!;
    public string LastName { get; } = default!;
    public string FirstName { get; } = default!;
    public string AddressLine { get; } = default!;
    public string EmailAddress { get; } = default!;

    protected Address() { }

    private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        State = state;
        ZipCode = zipCode;
        Country = country;
        LastName = lastName;
        FirstName = firstName;
        AddressLine = addressLine;
        EmailAddress = emailAddress;
    }

    public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}
