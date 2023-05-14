using College.Data.Classrooms.Contracts;
using College.Data.Classrooms.Contracts.Dtos;
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
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _service;
        public ClassroomController(IClassroomService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddClassroomDto dto, CancellationToken cancellationToken)
        {
            await _service.Add(dto, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<List<GetAllClassroomDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<GetClassroomById?>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }
    }
}
