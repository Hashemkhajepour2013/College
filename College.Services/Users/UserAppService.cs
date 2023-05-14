using AutoMapper;
using AutoMapper.QueryableExtensions;
using College.Common;
using College.Common.Exceptions;
using College.Data.Users.Contracts;
using College.Data.Users.Contracts.Dtos;
using College.Entities.Users;
using College.Services.JWT.Contracts;
using College.Services.JWT.Contracts.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace College.Services.Users
{
    public sealed class UserAppService : IUserService, IScopedDependency
    {
        private IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserAppService(
            IJwtService jwtService,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task Add(AddUserDto dto, CancellationToken cancellationToken)
        {
            var user = dto.ToEntity(_mapper);
            await _userManager.CreateAsync(user, dto.Password);

            await _userManager.AddToRoleAsync(user, dto.RoleName);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var user = await StopIfUserNotFound(id);

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.DeleteAsync(user);
        }

        //public async Task Edit(int id, EditUserDto dto, CancellationToken cancellationToken)
        //{
        //    var user = await StopIfUserNotFound(id);
                        
        //    await _userManager.UpdateAsync(dto.ToEntity(_mapper, user));
        //}

        public Task<List<GetAllUserDto>> GetAll(CancellationToken cancellationToken)
        {
            return _userManager.Users.ProjectTo<GetAllUserDto>(
                _mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        //public async Task<GetByIdUserDto?> GetById(
        //    int id,
        //    CancellationToken cancellationToken)
        //{
        //    var user = await StopIfUserNotFound(id);
        //    return GetByIdUserDto.FromEntity(_mapper, user);
        //}

        public async Task<AccessUserToken> Token(
            LoginUserDto dto,
            CancellationToken cancellationToken)
        {
            var user = await StopIfUserNotFound(dto.UserName);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            
            if (!isPasswordValid)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            return await _jwtService.Generate(user);
        }

        public async Task UpdateSecurityStamp(string userName)
        {
            var user = await StopIfUserNotFound(userName);

            await _userManager.UpdateSecurityStampAsync(user);
        }
        
        private async Task<User?> StopIfUserNotFound(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new NotFoundException("کاربری با این مشخصات یافت نشد");
            return user;
        }
        
        private async Task<User?> StopIfUserNotFound(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                throw new NotFoundException("کاربری با این مشخصات یافت نشد");
            return user;
        }
    }
}