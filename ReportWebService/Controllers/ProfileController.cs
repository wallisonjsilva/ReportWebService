using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportWebService.Model;
using ReportWebService.Services.Interfaces;

namespace ReportWebService.Controllers
{
    [ApiVersion("0.1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProfileController : ControllerBase
    {

        private readonly ILogger<ProfileController> _logger;

        private IProfileService _profileService;

        public ProfileController(ILogger<ProfileController> logger, IProfileService profileService)
        {
            _logger = logger;
            _profileService = profileService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var profile = _profileService.FindAll();
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var profile = _profileService.FindByID(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpGet("findProfileByName")]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get([FromQuery] string name)
        {
            var profile = _profileService.FindByName(name);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] Profile profile)
        {
            if (profile == null) return BadRequest();

            var result = _profileService.Create(profile);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Profile profile)
        {
            if (profile == null) return BadRequest();
            return Ok(_profileService.Update(profile));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType((200), Type = typeof(Profile))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Patch(long id, [FromBody] Profile profile)
        {

            if (profile.Disable) return Ok(_profileService.Disable(id));
            else return Ok(_profileService.Enable(id));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _profileService.Delete(id);
            return NoContent();
        }

    }
}
