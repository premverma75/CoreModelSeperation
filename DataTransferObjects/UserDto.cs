namespace CoreModelSeperation.DataTransferObjects
{
    public record CreateUserRequestDto(
      
       string Email,
       int MobileNumber,
       string Password,
       bool IsActive,
       string? FirstName,
       string? LastName
   );

    public record UpdateUserRequestDto(
        Guid UserId,
        string? FirstName,
        string? LastName,
        bool IsActive
    );

    public record UserResponseDto(
        Guid UserId,
        
        string Email,
        string? FirstName,
        string? LastName,
        bool IsActive,
        DateTimeOffset CreatedOn
    );
}