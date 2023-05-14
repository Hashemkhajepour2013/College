using College.Entities;
using College.MyApi;

namespace College.Data.Users.Contracts.Dtos
{
    public class GetByIdUserDto: BaseDto<GetByIdUserDto, User, int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string ImageName { get; set; }
    }
}
