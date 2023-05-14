using College.Data.Terms.Contracts;
using College.Data.Terms.Contracts.Dtos;
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
    public class TermController : ControllerBase
    {
        private readonly ITermService _service;
        public TermController(ITermService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Add(AddTermDto dto, CancellationToken cancellationToken)
        {
            await _service.Add(dto, cancellationToken);

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ApiResult> Edit(int id, EditTermDto dto, CancellationToken cancellationToken)
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

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin, User")]
        public async Task<ApiResult<GetTermByIdDto>> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }
    }
}
