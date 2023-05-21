using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Common.Exceptions;
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
            User? user = await StopIfUserNotFound(dto);

            await StopIfUserRoleNotFound(user);

            var student = dto.ToEntity(_mapper);

            await _repository.AddAsync(student, cancellationToken);
        }

        public async Task<GetStudentByIdDto?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Include(_ => _.User)
                .Where(_ => _.Id == id)
                .ProjectTo<GetStudentByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<GetAllStudentDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Include(_ => _.User)
                .ProjectTo<GetAllStudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        private async Task StopIfUserRoleNotFound(User? user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains("Student"))
                throw new BadRequestException("کاربر دارای نقش لازم نمی باشد");
        }

        private async Task<User?> StopIfUserNotFound(AddStudentDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                throw new NotFoundException("کاربر یافت نشد");
            return user;
        }
    }
}
