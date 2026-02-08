using CoreModelSeperation.DataTransferObjects;
using CoreModelSeperation.Domain;
using Mapster;

public static class EntityToDtoMapping
{
    public static void Register()
    {
        // --------------------
        // PRODUCT
        // --------------------

        TypeAdapterConfig<CreateProductRequestDto, Product>
            .NewConfig()
            .Compile();

        TypeAdapterConfig<UpdateProductRequestDto, Product>
            .NewConfig()
            .IgnoreNullValues(true) // 🔥 partial update
            .Compile();

        TypeAdapterConfig<Product, ProductResponseDto>
            .NewConfig()
            .Compile();

        // --------------------
        // USER
        // --------------------

        TypeAdapterConfig<CreateUserRequestDto, User>
            .NewConfig()
            .Map(dest => dest.PasswordHash,
                 src => BCrypt.Net.BCrypt.HashPassword(src.Password))
            .Map(dest => dest.IsActive,
                 _ => true)
            .Compile();

        TypeAdapterConfig<UpdateUserRequestDto, User>
            .NewConfig()
            .IgnoreNullValues(true)
            .Compile();

        TypeAdapterConfig<User, UserResponseDto>
            .NewConfig()
            .Compile();

        // --------------------
        // ORDER
        // --------------------

        TypeAdapterConfig<CreateOrderRequestDto, Order>
            .NewConfig()
            .Compile();

        TypeAdapterConfig<Order, OrderResponseDto>
            .NewConfig()
            .Compile();
    }
}