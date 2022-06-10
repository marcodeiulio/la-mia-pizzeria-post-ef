using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public static PizzaContext db = new PizzaContext();
        public static listaPizze pizze = null;

        public IActionResult Index()
        {
            //Pizza Fornarina = new Pizza("Fornarina", "Olio Evo, sale, pomodoro, rosmarino", 6.50, "img/fornarina.jpg");
            //Pizza Ciociara = new Pizza("Ciociara", "Pomodoro, fior di latte, pancetta croccante, radicchio, pecorino", 7.50, "img/ciociara.jpg");
            //Pizza Vegetariana = new Pizza("Vegetariana", "Pomodoro, fiordilatte, melanzane, zucchine, radicchio, pomini , rucola", 7.00, "img/vegetariana.jpg");
            //Pizza Romana = new Pizza("Romana", "Pomodoro, fior di latte, alici di Cetara, olive taggiasche, capperi", 8.50, "img/romana.jpg");
            //Pizza Sorrentina = new Pizza("Sorrentina", "Pomodoro, fior di latte, pomini, aglio, olive, capperi", 8.00, "img/sorrentina.jpg");
            //Pizza BellaNapoli = new Pizza("Bella Napoli", "Pomodoro, origano, alici di Cetara, burratina", 9.50, "img/bella-napoli.jpg");

            //pizze = new();
            //pizze.pizzas.Add(Fornarina);
            //pizze.pizzas.Add(Ciociara);
            //pizze.pizzas.Add(Vegetariana);
            //pizze.pizzas.Add(Romana);
            //pizze.pizzas.Add(Sorrentina);
            //pizze.pizzas.Add(BellaNapoli);

            //db.Add(Fornarina);
            //db.Add(Ciociara);
            //db.Add(Vegetariana);
            //db.Add(Romana);
            //db.Add(Sorrentina);
            //db.Add(BellaNapoli);
            //db.SaveChanges();

            return View(db);
        }

        // SHOW
        public IActionResult Show(Pizza pizza)
        {

            return View("Show", pizza);
        }

        // CREATE
        public IActionResult CreaNuovaPizza()
        {
            Pizza NuovaPizza = new Pizza()
            {
                Name = "",
                Description = "",
                Price = 0.0,
                Photo = "",

            };

            return View(NuovaPizza);
        }

        public IActionResult ShowPizza(Pizza pizza)
        {

            if (!ModelState.IsValid)
            {
                return View("CreaNuovaPizza", pizza);
            }

            Pizza nuovaPizza = new Pizza()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                Photo = pizza.Photo,

            };
            db.Add(nuovaPizza);
            db.SaveChanges();
            return View("ShowPizza", nuovaPizza);
        }

        // UPDATE
        public IActionResult AggiornaPizza(Pizza pizza)
        {

            return View("AggiornaPizza", pizza);
        }

        // EDIT
        public IActionResult EditPizza(Pizza pizza)
        {
            Pizza updatePizza = new Pizza();

            if (pizza != null)
            {

                updatePizza = db.Pizzas.Find(pizza.Id);

                updatePizza.Name = pizza.Name;
                updatePizza.Description = pizza.Description;
                updatePizza.Price = pizza.Price;
                if (updatePizza.Photo != pizza.Photo)
                {
                    updatePizza.Photo = pizza.Photo;
                }
                db.Update(updatePizza);
                db.SaveChanges();
            }

            return View("Show", updatePizza);
        }

        // DELETE
        public IActionResult RimuoviPizza(Pizza pizza)
        {
            return View("RimuoviPizza", pizza);
        }

        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            Pizza updatePizza = db.Pizzas.Find(pizza.Id);

            if (updatePizza.Id == pizza.Id)
            {
                db.Remove(updatePizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}