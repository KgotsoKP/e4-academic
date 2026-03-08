using Microsoft.AspNetCore.Mvc;

namespace Academic.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}