//using RealPizza.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace RealPizza.Controllers
//{
//    public class AddToCartController : Controller
//    {
//        // GET: Cart
//        public ActionResult Index()
//        {
//            var carrello = Session["Carrello"] as List<Pizze> ?? new List<Pizze>();
//            return View();
//        }

//        public ActionResult AddToCart(int id)
//        {
//            var dbContext = new ModelDbContext();
//            var pizza = dbContext.Pizze.Find(id);
//            if (pizza != null)
//            {
//                var carrello = Session["Carrello"] as List<Pizze> ?? new List<Pizze>();
//                carrello.Add(pizza);
//                Session["Carrello"] = carrello;
//            }
//            else
//            {
//                return HttpNotFound();
//            }

//            return View();
//        }

//        public ActionResult RemoveFromCart(int id)
//        {
//            var carrello = Session["Carrello"] as List<Pizze> ?? new List<Pizze>();
//            var pizza = carrello.FirstOrDefault(p => p.ID_Pizza == id);
//            if (pizza != null)
//            {
//                carrello.Remove(pizza);
//                Session["Carrello"] = carrello;
//            }
//            else
//            {
//                return HttpNotFound();
//            }
//            return View();
//        }
//    }
//}