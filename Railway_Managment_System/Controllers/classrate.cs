using Microsoft.AspNetCore.Mvc;
using Railway_Managment_System.Models;

namespace Railway_Managment_System.Controllers
{
    public class classrate : Controller
    {
        RailwayContext db = new RailwayContext();
        public IActionResult rates()
        {
            return View();
        }


        
    }
}
