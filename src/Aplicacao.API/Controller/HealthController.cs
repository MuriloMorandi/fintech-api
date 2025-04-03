using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class healthController : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
    }
    
}