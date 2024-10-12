using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Railway_Managment_System.Models;
using System.Security.Claims;

namespace Railway_Managment_System.Controllers
{
    public class login : Controller
    {
        RailwayContext db = new RailwayContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login my_data)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;


            var res = db.Logins.FirstOrDefault(x => x.Email == my_data.Email && x.Password == my_data.Password);
            if (res != null)
            {


                if (res.Roletype == 0)
                {

                    //Create the identity for the user
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,my_data.Email),
                    new Claim(ClaimTypes.Sid, res.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }

                if (res.Roletype == 1)
                {
                    //Create the identity for the user
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, my_data.Email),
                     new Claim(ClaimTypes.Sid, res.Id.ToString()),
                    new Claim(ClaimTypes.Role, "stationmaster")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }




                if (res.Roletype == 2)
                {
                    //Create the identity for the user
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, my_data.Email),
                    new Claim(ClaimTypes.Sid, res.Id.ToString()),
                    new Claim(ClaimTypes.Role, "trainmaster")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }

                if (isAuthenticated && res.Roletype == 0)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("TrainMaster", "Home");
                    
                }




                else if (isAuthenticated && res.Roletype == 1)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("passengerdetail", "PassengerDetail");
                }
                else if (isAuthenticated && res.Roletype == 2)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("TrainMaster","Home");
                }



            }


            return View();



           
        }


        public IActionResult logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }



}
