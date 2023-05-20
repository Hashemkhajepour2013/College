using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Data.Users.Students.Contracts;
using College.Data.Users.Students.Contracts.Dtos;
using College.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<GetStudentByIdDto?> GetById(int userId, CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Include(_ => _.User)
                .ProjectTo<GetStudentByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
