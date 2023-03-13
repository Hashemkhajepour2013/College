namespace College.Entities;

public sealed class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string NationalCode { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}