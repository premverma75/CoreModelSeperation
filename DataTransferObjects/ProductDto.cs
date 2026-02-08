namespace CoreModelSeperation.DataTransferObjects
{
    public record CreateProductRequestDto(
     string Name,
     string Description,
     decimal Price,
     int StockQuantity
 );

    public record UpdateProductRequestDto(
        Guid ProductId,
        string? Name,
        string? Description,
        decimal? Price,
        int? StockQuantity
    );

    public record ProductResponseDto(
        Guid ProductId,
        string Name,
        string Description,
        decimal Price,
        int StockQuantity,
        bool IsActive
    );
}