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

        private void AggiornaBadgeCarrello()
        {
            var carrello = Session["Carrello"] as List<Pizze>;
            var numeroArticoli = carrello?.Count ?? 0;

            Session["BadgeCarrello"] = numeroArticoli;
        }

        [HttpPost]
        public ActionResult Ordina(string note, string indirizzo)
        {
            ModelDbContext db = new ModelDbContext();
            int userId = db.Users.FirstOrDefault(u => u.Username == User.Identity.Name)?.ID_Utente ?? 0;
            int quantita = (Session["Carrello"] as List<Pizze>)?.Count ?? 0;

            if (userId != 0 && Session["Carrello"] is List<Pizze> cart && cart.Any())
            {
                foreach (var pizza in cart)
                {
                    Ordini newOrder = new Ordini();
                    newOrder.FK_ID_Utente = userId;
                    newOrder.FK_ID_Pizza = pizza.ID_Pizza;
                    newOrder.Indirizzo_Consegna = indirizzo;
                    newOrder.Totale = pizza.Prezzo;
                    newOrder.Note = note;
                    newOrder.Quantita = quantita;

                    db.Ordini.Add(newOrder);
                }
                db.SaveChanges();
                cart.Clear();

                // Rimuovi il carrello dalla sessione e aggiorna il badge del carrello
                Session.Remove("Carrello");
                AggiornaBadgeCarrello();

                TempData["OrderConfirm"] = "Ordine effettuato con successo!";
            }

            return RedirectToAction("Index", "Pizze");
        }
    }
}