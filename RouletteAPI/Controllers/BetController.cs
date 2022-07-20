using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Business.BetBusiness;
using RouletteAPI.Model;

namespace RouletteAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class BetController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    /// <summary>
    /// Place a bet by providing a Bet Type
    /// </summary>
    /// <remarks> <strong>Bet Types</strong><br/>
    /// 1 = Dozen bet.The first 12 numbers. From 1 to 12 <br/>
    /// 2 = Dozen bet. The 12 middle numbers. From 13 to 24 <br/>
    /// 3 = Dozen bet. The last 12 numbers. From 25 to 36 <br/>
    /// 4 = Low or Manque. The first half numbers. From 1 to 18 <br/>
    /// 5 = High or Passe. The second half numbers. From 19 to 36 <br/>
    /// 6 = Even numbers from 1 to 36; <br/>
    /// 7 = Odd numbers from 1 to 36; <br/>
    /// 8 = Straight/Single. From 1 to 36, Kindly provide a staright number if you choose this option <br/>
    /// Any Bet Type number out of 1-8 range will return a validation error<br/>
    /// straightNumber is not required/being used unless the betType = 8
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post(PlaceBetModel bet)
    {
        try
        {
            if (!ModelState.IsValid)
                return ValidationProblem(string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
            var result = await new Bet().PlaceBet(bet);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
