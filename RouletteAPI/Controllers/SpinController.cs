using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Business.SpinBusiness;

namespace RouletteAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class SpinController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    /// <summary>
    /// Get previous spins
    /// </summary>
    /// <remarks>
    /// page (optional): pagination. if the page value is null, the first will be loaded <br/>
    /// pageSize (optional): number of records per page. if the pageSize value is null, the default value of 10 will be used
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> Get(int? page, int? pageSize)
    {
        try
        {
            var previousSpins = await new PreviousSpins().GetSpins(page, pageSize);
            return Ok(previousSpins);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Run Roulette wheel spin
    /// </summary>
    /// <remarks>
    /// This will return the a random wheel number between 1 and 36
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        try
        {
            var result = await new Spin().Run();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
