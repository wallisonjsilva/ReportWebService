using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportWebService.Model;
using ReportWebService.Services.Interfaces;

namespace ReportWebService.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        private IReportService _reportService;

        public ReportController(ILogger<ReportController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var report = _reportService.FindAll();
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var report = _reportService.FindByID(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpGet("findReportByName")]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string name)
        {
            var report = _reportService.FindByName(name);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Report report)
        {
            if (report == null) return BadRequest();

            var result = _reportService.Create(report);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Report report)
        {
            if (report == null) return BadRequest();
            return Ok(_reportService.Update(report));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(Report))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch(long id, [FromBody] Report report)
        {

            if (report.Disable) return Ok(_reportService.Disable(id));
            else return Ok(_reportService.Enable(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _reportService.Delete(id);
            return NoContent();
        }
    }
}
