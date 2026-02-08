namespace CoreModelSeperation.DataTransferObjects
{
    public record OrderItemDto(
     Guid ProductId,
     int Quantity,
     decimal UnitPrice
 );

    public record CreateOrderRequestDto(
        Guid UserId,
        List<OrderItemDto> Items
    );

    public record OrderResponseDto(
        Guid OrderId,
        Guid UserId,
        decimal TotalAmount,
        string Status,
        DateTimeOffset OrderDate,
        IReadOnlyList<OrderItemDto> Items
    );
}