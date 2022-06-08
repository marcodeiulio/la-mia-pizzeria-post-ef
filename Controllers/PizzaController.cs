using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

//Ciao ragazzi, andiamo avanti con l'applicazione per gestire la nostra pizzeria.
//Lo scopo di oggi è quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.
//Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d'ora in avanti.
//L'elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l'html corretto.
//Gestiamo anche la possibilità che non ci siano pizze nell'elenco:
//in quel caso dobbiamo mostrare un messaggio che indichi all'utente che non ci sono pizze presenti nella nostra applicazione.
//Ogni pizza dell'elenco avrà un pulsante che se cliccato ci porterà a una pagina che mostrerà i dettagli di quella singola pizza.
//Dobbiamo quindi inviare l'id come parametro dell'URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.
//La view a quel punto li mostrerà all'utente con la grafica che preferiamo.
//Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il "mapping di default" dei controller, altrimenti quale pagina viene caricata se richiamo l'url "/" della nostra webapp?


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public static PizzasList pizze;
        public IActionResult Index()
        {
            Pizza Fornarina = new Pizza(0,"Fornarina", "Olio Evo, sale, pomodoro, rosmarino", 6.50,"img/fornarina.jpg");
            Pizza Ciociara = new Pizza(1,"Ciociara", "Pomodoro, fior di latte, pancetta croccante, radicchio, pecorino", 7.50, "img/ciociara.jpg");
            Pizza Vegetariana = new Pizza(2,"Vegetariana", "Pomodoro, fiordilatte, melanzane, zucchine, radicchio, pomini , rucola", 7.00, "img/vegetariana.jpg");
            Pizza Romana = new Pizza(3,"Romana", "Pomodoro, fior di latte, alici di Cetara, olive taggiasche, capperi", 8.50, "img/romana.jpg");
            Pizza Sorrentina = new Pizza(4,"Sorrentina", "Pomodoro, fior di latte, pomini, aglio, olive, capperi", 8.00, "img/sorrentina.jpg");
            Pizza BellaNapoli = new Pizza(5,"Bella Napoli", "Pomodoro, origano, alici di Cetara, burratina", 9.50, "img/bella-napoli.jpg");

            pizze = new();
            pizze.pizzas.Add(Fornarina);
            pizze.pizzas.Add(Ciociara);
            pizze.pizzas.Add(Vegetariana);
            pizze.pizzas.Add(Romana);
            pizze.pizzas.Add(Sorrentina);
            pizze.pizzas.Add(BellaNapoli);

            return View(pizze);
        }


        public IActionResult Show(int id)
        { 
            return View("Show", pizze.pizzas[id]);
        }
        public IActionResult CreaNuovaPizza()
        {
            Pizza NuovaPizza = new Pizza
            {
                Id = pizze.pizzas.Count + 1,
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

            Pizza nuovaPizza = new Pizza
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                Photo = pizza.Photo,

            };
            pizze.pizzas.Add(nuovaPizza);
            return View("ShowPizza", nuovaPizza);
        }


        public IActionResult AggiornaPizza(Pizza pizza)
        {

            return View("AggiornaPizza", pizza);
        }

        public IActionResult EditPizza(Pizza pizza)
        {
            //Pizza updatePizza = new Pizza();
            //updatePizza = (Pizza)pizze.pizzas.Where(x => x.Id == pizza.Id);

            Pizza updatePizza = pizze.pizzas.Find(x => x.Id == pizza.Id);

            updatePizza.Name = pizza.Name;
            updatePizza.Description = pizza.Description;
            updatePizza.Price = pizza.Price;
            if (updatePizza.Photo != pizza.Photo)
            {
                updatePizza.Photo = pizza.Photo;
            }



            return View("Show", updatePizza);
        }




        public IActionResult RimuoviPizza(Pizza pizza)
        {

            return View("RimuoviPizza", pizza);
        }



        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            Pizza updatePizza = pizze.pizzas.Find(x => x.Id == pizza.Id);
            if (updatePizza.Id == pizza.Id)
            {
                var ok = pizze.pizzas.Remove(updatePizza);
                Console.WriteLine(ok);
            }
            return RedirectToAction("Index");
        }
    }
}
