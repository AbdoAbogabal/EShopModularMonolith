namespace Ordering.Orders.DTOS;

public record PaymentDto(
    string CardName,
    string CardNumber,
    string Expiration,
    string CVV,
    int PaymentType);
