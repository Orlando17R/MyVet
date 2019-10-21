using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyVet.Web.Models;

namespace MyVet.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel modell)
        {
            //return View();
            if (!ModelState.IsValid)
            {
                
            }

            return View(modell);

        }
    }
}
