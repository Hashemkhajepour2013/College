using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Common.Exceptions;
using College.Data.Users.Professors.Contracts;
using College.Data.Users.Professors.Contracts.Dtos;
using College.Data.Users.Students.Contracts.Dtos;
using College.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace College.Services.Users.Professors
{
    public class ProfessorAppService : IProfessorService, IScopedDependency
    {
        private readonly IProfessorRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public ProfessorAppService(
            IProfessorRepository repository,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;

        }

        public async Task Add(AddProfessorDto dto, CancellationToken cancellationToken)
        {
            User? user = await StopIfUserNotFound(dto);

            await StopIfUserRoleNotFound(user);

            var professor = dto.ToEntity(_mapper);

            await _repository.AddAsync(professor, cancellationToken);
        }

        public async Task<GetProfessorByIdDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Include(_ => _.User)
                .Where(_ => _.Id == id)
                .ProjectTo<GetProfessorByIdDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task StopIfUserRoleNotFound(User? user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Contains("Professor"))
                throw new BadRequestException("کاربر دارای نقش لازم نمی باشد");
        }

        private async Task<User?> StopIfUserNotFound(AddProfessorDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                throw new NotFoundException("کاربر یافت نشد");
            return user;
        }

        public async Task<List<GetAllProfessorDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _repository.TableNoTracking
                .Include(_ => _.User)
                .ProjectTo<GetAllProfessorDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
