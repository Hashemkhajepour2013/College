using College.Entities.Users;
using College.MyApi;

namespace College.Data.Users.Contracts.Dtos
{
    public class GetAllUserDto: BaseDto<GetAllUserDto, User, int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string ImageName { get; set; }
    }
}
