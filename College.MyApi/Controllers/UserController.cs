using College.Data.Users.Contracts;
using College.Data.Users.Contracts.Dtos;
using College.WebFrameWork.Api;
using College.WebFrameWork.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace College.MyApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddUserDto dto, CancellationToken cancellationToken)
        {
            dto.UsernameOfMaker = HttpContext.User.Identity.Name;
            await _service.Add(dto, cancellationToken);
            return Ok();
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ApiResult<List<GetAllUserDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Edit(int id, EditUserDto dto, CancellationToken cancellationToken)
        {
            await _service.Edit(id, dto, cancellationToken);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ApiResult<GetByIdUserDto>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        [HttpPost("Token")]
        public async Task<ActionResult> Token([FromForm] LoginUserDto dto, CancellationToken cancellationToken)
        {
            return new JsonResult(await _service.Token(dto, cancellationToken));
        }

        [AllowAnonymous]
        [HttpPost("invalid-token")]
        public async void InvalidTokens([Required]string userName)
        {
           await _service.UpdateSecurityStamp(userName);
        }
    }
}
