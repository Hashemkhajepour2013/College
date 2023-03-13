using College.EFDataAccessLayer.Terms.Contracts;
using College.EFDataAccessLayer.Terms.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace College.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermController : ControllerBase
    {

        private readonly ITermService _service;
        public TermController(ITermService service)
        {
            _service = service;
        }

        /// <summary>
        ///  This Method generate Term
        /// </summary>
        /// <param name="dto">the information for create term</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<int> Add(AddTermDto dto, CancellationToken cancellationToken)
        {
            return _service.Add(dto, cancellationToken);
        }
    }
}
