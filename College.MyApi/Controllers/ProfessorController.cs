using College.Data.Users.Professors.Contracts;
using College.Data.Users.Professors.Contracts.Dtos;
using College.Data.Users.Students.Contracts.Dtos;
using College.WebFrameWork.Api;
using College.WebFrameWork.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace College.MyApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddProfessorDto dto, CancellationToken cancellationToken)
        {
            await _service.Add(dto, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<GetProfessorByIdDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<List<GetAllProfessorDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }
    }
}
