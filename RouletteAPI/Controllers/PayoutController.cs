using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Model;

namespace RouletteAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class PayoutController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    /// <summary>
    /// Cashout
    /// </summary>
    /// <remarks>
    /// This is a dummy endpoint. Use Bet and Spin endpoints to test the app.
    /// </remarks>
    [HttpPost]
    public IActionResult Post()
    {
        return Ok(new PayoutModel());
    }
}
