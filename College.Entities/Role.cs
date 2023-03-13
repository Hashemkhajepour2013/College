namespace College.Entities;

public sealed class Role : BaseEntity
{
    public string Title { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}