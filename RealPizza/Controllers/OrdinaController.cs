using RealPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealPizza.Controllers
{
    public class OrdinaController : Controller
    {
        // GET: Ordina
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ordina(string note, string indirizzo)
        {
            ModelDbContext db = new ModelDbContext();
            var userId = db.Users.FirstOrDefault(u => u.Username == User.Identity.Name).ID_Utente;
            var cart = Session["Carrello"] as List<Pizze>;

            if (cart != null && cart.Any())
            {
                foreach (var pizza in cart)
                {
                    Ordini newOrder = new Ordini();
                    newOrder.FK_ID_Utente = userId;
                    newOrder.FK_ID_Pizza = pizza.ID_Pizza; // Ottieni l'ID della pizza dall'oggetto pizza nel carrello
                    newOrder.Indirizzo_Consegna = indirizzo;
                    newOrder.Totale = pizza.Prezzo; // Usa il prezzo della pizza come totale dell'ordine
                    newOrder.Note = note;

                    db.Ordini.Add(newOrder);
                }

                db.SaveChanges();
                cart.Clear();
            }

            TempData["CreateMess"] = "L'ordine è stato inviato correttamente";
            return RedirectToAction("Index", "Pizze");
        }



    }
}