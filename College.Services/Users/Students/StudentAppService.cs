using AutoMapper;
using College.Common;
using College.Data.Repositories;
using College.Data.Users.Students.Contracts;
using College.Data.Users.Students.Contracts.Dtos;
using College.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace College.Services.Users.Students
{
    public class StudentAppService : IStudentService, IScopedDependency
    {
        private readonly IStudentRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public StudentAppService(
            IStudentRepository repository,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Add(AddStudentDto dto, CancellationToken cancellationToken)
        {
            var user = dto.ToEntity(_mapper);

            await _userManager.CreateAsync(user, dto.Password);

            await _userManager.AddToRoleAsync(user, "User");

            var student = new Student
            {
                ConditionalSemesters = dto.ConditionalSemesters,
                EntryDate = dto.EntryDate,
                Grade = dto.Grade,
                GraduationDate = dto.GraduationDate,
                SemestersTaken = dto.SemestersTaken,
                State = dto.State,
                UserId = user.Id
            };

            await _repository.AddAsync(student, cancellationToken);
        }
    }
}
