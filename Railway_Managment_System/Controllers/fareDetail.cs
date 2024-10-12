using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Railway_Managment_System.Models;
using System.Linq;

namespace Railway_Managment_System.Controllers
{
    public class fareDetail : Controller
    {
        RailwayContext db = new RailwayContext();

        public IActionResult Fare()
        {

            ViewBag.train = new SelectList(db.Trains, "Id", "TrainName");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult AddFare(FareDetail my_data)
        {


            db.FareDetails.Add(my_data);
            db.SaveChanges();


            return RedirectToAction("Fare", "fareDetail");
        }


        public IActionResult faredata()
        {

          
            return View(db.FareDetails.ToList());
        }


        public IActionResult fareDelete(int id)
        {
            var fare = db.FareDetails.FirstOrDefault(x => x.FId == id);

            if(fare != null)
            {
                db.FareDetails.Remove(fare);
                db.SaveChanges();
            }
            return RedirectToAction("faredata", "fareDetail");
            

        }



        public IActionResult editfare(int id)
        {
            var newfare = db.FareDetails.FirstOrDefault(x => x.FId == id);
            if(newfare != null)
            {
                ViewBag.farerate = newfare.Rate;
                ViewBag.train = new SelectList(db.Trains, "Id", "TrainName");

            }
            return View(newfare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFare(FareDetail abc)
        {
            if (abc == null)
            {
                return BadRequest("No data received.");
            }

            Console.WriteLine($"Received FId: {abc.FId}");

            var existingFare = db.FareDetails.Find(abc.FId);
            if (existingFare != null)
            {
                db.Entry(existingFare).CurrentValues.SetValues(abc);

                try
                {
                    db.SaveChanges();
                    Console.WriteLine("Update successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Update failed: {ex.Message}");
                    return StatusCode(500, "Internal server error");
                }

                return RedirectToAction("faredata", "fareDetail");
            }

            Console.WriteLine("FareDetail not found.");
            return NotFound();
        }




    }





}
