namespace la_mia_pizzeria_static.Models
{
    public class listaPizze
    {
        public List<Pizza> pizzas { get; set; }

        public listaPizze()
        {
            pizzas = new List<Pizza>();
        }
    }
}