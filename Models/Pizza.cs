using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzeriaDB;Integrated Security=True;Pooling=False");
        }
    }

    [Table("pizza")]
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome della pizza è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descrizione della pizza è obbligatoria")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio")]
        public double Price { get; set; }
        public string? Photo { get; set; }

        public Pizza(string Nome, string Descizione, double Prezzo, string Foto)
        {
            this.Name = Nome;
            this.Description = Descizione;
            this.Price = Prezzo;
            this.Photo = Foto;
        }
        public Pizza()
        { }
    }


}
