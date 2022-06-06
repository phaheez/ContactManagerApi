using ContactManagerApi.Interfaces;
using ContactManagerApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerApi.Controllers
{
    [Route("api/designation")]
    [ApiController]
    public class DesignationsController : BaseApiController
    {
        private readonly IDesignationService _designationService;

        public DesignationsController(IDesignationService designationService)
        {
            _designationService = designationService ?? throw new ArgumentNullException(nameof(designationService));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var getDesignationsResponse = await _designationService.GetDesignationsAsync();

            if (!getDesignationsResponse.Success)
            {
                return UnprocessableEntity(getDesignationsResponse);
            }

            var designationsResponse = getDesignationsResponse.Designations.ConvertAll(o => new DesignationResponse
            {
                Id = o.Id,
                Name = o.Name
            });

            return Ok(designationsResponse);
        }
    }
}
