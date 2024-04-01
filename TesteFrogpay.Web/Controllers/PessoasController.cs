using Microsoft.AspNetCore.Mvc;

namespace TesteFrogpay.Web.Controllers;

public class PessoasController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}