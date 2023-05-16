using AutoMapper;
using College.Common;
using College.Data.Users.Students.Contracts;
using College.Data.Users.Students.Contracts.Dtos;
using College.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace College.Services.Users.Students
{
    public class StudentAppService : IStudentService, IScopedDependency
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public StudentAppService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Add(AddStudentDto dto, CancellationToken cancellationToken)
        {
            var user = dto.ToEntity(_mapper);

            await _userManager.CreateAsync(user, dto.Password);

            await _userManager.AddToRoleAsync(user, "User");
        }
    }
}
