using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Railway_Managment_System.Models;
using System.Net.Mail;
using System.Net;
using System.Numerics;

namespace Railway_Managment_System.Controllers
{
    public class PassengerDetail : Controller
    {
        RailwayContext db = new RailwayContext();   
        public IActionResult passengerdetail()
        {


            ViewBag.train = new SelectList(db.Trains, "Id", "TrainName");


            return View();

            
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult addpassenger(Ticket my_data)
        {
           
            if (ModelState.IsValid)
            {
                db.Tickets.Add(my_data);
                db.SaveChanges();
            }

            return RedirectToAction("passengerdetail","PassengerDetail");
        }



        public IActionResult passengerdata()
        {
            return View(db.Tickets.ToList());
        }


        public IActionResult passengerdelete(int id)
        {
          
            var ticket = db.Tickets.FirstOrDefault(x => x.TicketId == id);

            if (ticket != null)
            {
                db.Tickets.Remove(ticket);
                db.SaveChanges();
            }

       
            return RedirectToAction("passengerdata", "PassengerDetail");
        }



        public IActionResult passengeredit(int id)
        {
            var ticket = db.Tickets.Find(id);
            ViewBag.train = new SelectList(db.Trains, "Id", "TrainName");

            return View(ticket);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PassengerUpdate(Ticket my_data)
        {
            
            if (my_data == null)
            {
               
                return BadRequest("No data received.");
            }

           
            Console.WriteLine($"Received TicketId: {my_data.TicketId}");

            
            var existingTicket = db.Tickets.Find(my_data.TicketId);
            if (existingTicket != null)
            {
               
                db.Entry(existingTicket).CurrentValues.SetValues(my_data);

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

                return RedirectToAction("passengerdata", "PassengerDetail");
            }

            
            Console.WriteLine("Ticket not found.");
            return NotFound();
        }






        public IActionResult cancelticket(int id)
        {

            var a = db.Tickets.Find(id);

            if(a != null)
            {
                ViewBag.name = a.Name;
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult passengercancel(CancelTicket my_data,string pname)
        {
            
                db.CancelTickets.Add(my_data);
                db.SaveChanges();

              
           
           
            return RedirectToAction("cancelticket","PassengerDetail");
        }


        public IActionResult canceldata()
        {
            
            return View(db.CancelTickets.ToList());
        }


        public IActionResult FinalCancelTicket(CancelTicket useremail,int id)
        {

            var one = db.CancelTickets.Find(id);


            if(one != null)
            {
                var email = one.PassengerEmail;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("shaheerking168@gmail.com", "iwaj ncrs ycry qxhn");

                MailMessage msg = new MailMessage("shaheerking168@gmail.com",email);
                msg.Subject = "Indian Railway Ticket Cancellation Alert";
                msg.Body = "Dear Passenger, your Ticket has been Cancelled and we Minus 200 rupees in your amount Because that is company Policy.";

                // msg.Attachments.Add(new Attachment(PathToAttachment));
                client.Send(msg);

                ViewBag.message = "Mail sent successfully,";

                
               


            }

          
            return RedirectToAction("canceldata","PassengerDetail");

        }


    }
}
