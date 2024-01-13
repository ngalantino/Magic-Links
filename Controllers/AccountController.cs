using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MagicLinks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return Ok(new
            {
                Message = "Unrecognized user. You must sign in to use this weather service.",
                LoginUrl = Url.ActionLink(action: "", controller: "Account", values:
                new
                {
                    ReturnURL = returnURL
                },
                protocol: Request.Scheme),
                Schema = "{ \n userName * string \n email * string ($email) \n }"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var returnUrl = HttpContext?.Request.Query.FirstOrDefault(r => r.Key == "returnUrl");

            if (user is null)
            {
                return Unauthorized();
            }
            else
            {
                // Our authentication code here...
                return Unauthorized();
            }
        }


    }
}
