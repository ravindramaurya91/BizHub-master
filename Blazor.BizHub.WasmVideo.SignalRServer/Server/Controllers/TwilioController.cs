using System.Threading.Tasks;
using Blazor.BizHub.WasmVideo.SignalRServer.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.BizHub.WasmVideo.SignalRServer.Server.Controllers
{
    [
        ApiController,
        Route("api/twilio")
    ]
    public class TwilioController : ControllerBase
    {
        [HttpGet("token")]
        public IActionResult GetToken(
            [FromServices] TwilioService twilioService) =>
             new JsonResult(twilioService.GetTwilioJwt(User.Identity.Name));

        [HttpGet("rooms")]
        public async Task<IActionResult> GetRooms(
            [FromServices] TwilioService twilioService) =>
            new JsonResult(await twilioService.GetAllRoomsAsync());
    }
}
