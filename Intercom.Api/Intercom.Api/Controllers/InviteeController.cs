using System;
using System.Threading.Tasks;
using Intercom.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intercom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InviteeController : ControllerBase
    {
        private IInvitationService _invitationService;

        public InviteeController(IInvitationService invitationService)
        {
            _invitationService = invitationService ?? throw new ArgumentNullException(nameof(invitationService)); ;
        }

        [HttpPost]
        [Consumes("application/json","application/json-patch+json", "multipart/form-data")]
        public async Task<ActionResult> PostAsync(IFormFile file)
        {
            var response = await _invitationService.InviteToDublinOfficeAsync(file);
            return Ok(response);
        }
    }
}
