using College.Data.Lessons.Contracts;
using College.Data.Lessons.Contracts.Dtos;
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
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddLessonDto dto, CancellationToken cancellationToken)
        {
            await _service.Add(dto, cancellationToken);

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Edit(int id, EditLessonDto dto, CancellationToken cancellationToken)
        {
            await _service.Edit(id, dto, cancellationToken);

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
        public async Task<ApiResult<List<GetAllLessonDto>>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ApiResult<GetLessonById>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }
    }
}
