using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionarePacienti.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext == null)
                throw new ArgumentNullException("HttpContext");
            else if (HttpContext.User == null)
                throw new ArgumentNullException("HttpContext.User");
            else if (HttpContext.User.Identity == null)
                throw new ArgumentNullException("HttpContext.User.Identity");
            else
            {
                //https://stackoverflow.com/questions/33057838/httpcontext-is-null-for-mvc-controller/33057885

                TempData["userName"] = HttpContext.User.Identity.Name.Split('@')[0];
            }

            return View();
        }
    }
}
