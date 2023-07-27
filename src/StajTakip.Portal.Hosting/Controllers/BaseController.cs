using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StajTakip.Portal.Hosting.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        
    }
}
