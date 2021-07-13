using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportWebService.Model;
using ReportWebService.Services;

namespace ReportWebService.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;

        private ITenantService _tenantService;

        public TenantController(ILogger<TenantController> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var tenant = _tenantService.FindAll();
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var tenant = _tenantService.FindByID(id);
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpGet("findTenantByName")]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string name)
        {
            var tenant = _tenantService.FindByName(name);
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Tenant tenant)
        {
            if (tenant == null) return BadRequest();

            var result = _tenantService.Create(tenant);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Tenant tenant)
        {
            if (tenant == null) return BadRequest();
            return Ok(_tenantService.Update(tenant));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(Tenant))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch(long id, [FromBody] Tenant tenant)
        {

            if (tenant.Disable) return Ok(_tenantService.Disable(id));
            else return Ok(_tenantService.Enable(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _tenantService.Delete(id);
            return NoContent();
        }
    }
}
