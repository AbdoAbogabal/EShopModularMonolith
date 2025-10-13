namespace Ordering.Orders.ValueObjects;

public class Payment
{
    public string CVV { get; } = default!;
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;

    public int PaymentMethod { get; } = default!;

    protected Payment() { }

    private Payment(string cvv, string cardName, string cardNumber, string expiration, int paymentMethod)
    {
        CVV = cvv;
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cvv, string cardName, string cardNumber, string expiration, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);

        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cvv, cardName, cardNumber, expiration, paymentMethod);
    }
}
