using System.Security.Claims;
using CreditUnion.Api.Contracts;
using CreditUnion.Api.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreditUnion.Api.Controllers;

[ApiController]
[Route("api/session")]
public sealed class SessionController : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType<SessionResponse>(StatusCodes.Status200OK)]
    public ActionResult<SessionResponse> GetSession()
    {
        var authenticated = User.Identity?.IsAuthenticated == true;
        return Ok(new SessionResponse(authenticated, authenticated ? User.Identity?.Name : null));
    }

    [HttpPost("demo")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> StartDemoSession(DemoLoginRequest request)
    {
        if (request.UserId != "demo.member" || request.Password != "demo123")
        {
            return Unauthorized();
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, DemoDataSeeder.DemoMemberId),
            new Claim(ClaimTypes.Name, "Alex Morgan")
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return NoContent();
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EndSession()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return NoContent();
    }
}