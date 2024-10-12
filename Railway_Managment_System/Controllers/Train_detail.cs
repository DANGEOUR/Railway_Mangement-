using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Railway_Managment_System.Models;

namespace Railway_Manegement_system.Controllers
{
    public class Train_detail : Controller
    {
        RailwayContext db = new RailwayContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult trainadd(Train my_data)
        {

            if (ModelState.IsValid)
            {
                db.Trains.Add(my_data);
                db.SaveChanges();
            }

            return RedirectToAction("train_data", "Train_detail");
        }

        public IActionResult train_data()
        {


            return View(db.Trains.ToList());
        }


        public IActionResult TrainDelete(int id)
        {

            var idd = db.Trains.FirstOrDefault(x => x.Id == id);

            if(idd != null)
            {
                db.Trains.Remove(idd);
                db.SaveChanges();
            }

            return RedirectToAction("train_data", "Train_detail");
        }




        public IActionResult Trainedit(int id)
        {
            var one = db.Trains.Find(id);

            return View(one);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TrainUpdate(Train my_data)
        {
            // Debugging: Check incoming data
            if (my_data == null)
            {
                // Log error or return a bad request
                return BadRequest("No data received.");
            }

            // Log the received data
            Console.WriteLine($"Received TrainId: {my_data.Id}");

            // Find the existing entity
            var existingTrain = db.Trains.Find(my_data.Id);
            if (existingTrain != null)
            {
                // Update the properties of the existing entity
                db.Entry(existingTrain).CurrentValues.SetValues(my_data);

                try
                {
                    db.SaveChanges();
                    // Log success
                    Console.WriteLine("Update successful.");
                }
                catch (Exception ex)
                {
                    // Log exception
                    Console.WriteLine($"Update failed: {ex.Message}");
                    // Return an error view or message
                    return StatusCode(500, "Internal server error");
                }

                return RedirectToAction("train_data", "train_detail");
            }

            // If the entity is not found, log the error and return not found result
            Console.WriteLine("Train not found.");
            return NotFound();
        }




    }
}
