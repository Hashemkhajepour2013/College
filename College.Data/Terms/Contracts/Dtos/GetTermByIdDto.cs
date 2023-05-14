using College.Entities;
using College.MyApi;

namespace College.Data.Terms.Contracts.Dtos
{
    public class GetTermByIdDto: BaseDto<GetTermByIdDto, Term>
    {
        public string Title { get; set; }

        public byte UnitCount { get; set; }
    }
}
