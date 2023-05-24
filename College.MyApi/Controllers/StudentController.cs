using College.Data.Users.Students.Contracts;
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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddStudentDto dto, CancellationToken cancellationToken)
        {
            await _service.Add(dto, cancellationToken);

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<GetStudentByIdDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<List<GetAllStudentDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        [HttpGet("classes-for-unit-select/{id}")]
        [Authorize(Roles = "Admin, Student")]
        public async Task<ApiResult<List<GetClassesForUnitSelectDto>>> GetClassesForUnitSelect(int id, CancellationToken cancellationToken)
        {
            return await _service.GetClassesForUnitSelect(id, cancellationToken);
        }
    }
}
