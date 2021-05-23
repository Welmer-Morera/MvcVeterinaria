using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcVeterinaria.Models;

namespace MvcVeterinaria.Controllers
{
    public class VeterinarioController : Controller{

        public IActionResult Index(){

            return View();
        }

    }
}