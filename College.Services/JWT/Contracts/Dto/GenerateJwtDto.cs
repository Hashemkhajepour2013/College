namespace College.Services.JWT.Contracts.Dto
{
    public sealed class GenerateJwtDto
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
