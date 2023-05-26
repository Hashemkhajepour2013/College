using College.Entities.Users;
using College.MyApi;

namespace College.Data.Users.Professors.Contracts.Dtos
{
    public class GetProfessorByIdDto: BaseDto<GetProfessorByIdDto, Professor>
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFatherName { get; set; }
        public string UserNationalCode { get; set; }
        public string UserMobile { get; set; }
        public string UserImageName { get; set; }
        public string DegreeOfEducation { get; set; }
        public string ContractType { get; set; }
    }
}
