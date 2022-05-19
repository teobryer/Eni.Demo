using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eni.TP_Pizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "{0} doit avoir une longueur comprise entre  {2} et {1}.", MinimumLength = 5)]
        public string Nom { get; set; }
     
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [MinLength(2, ErrorMessage = "{0} doit avoir au moins {1} ingrédients")]
        [MaxLength(5, ErrorMessage = "{0} doit avoir au maximum {1} ingrédients")]
        public List<int> ListeIngIds { get; set; } = new List<int>();
        [Required]
        public int PateId { get; set; }


        public static List<Ingredient> IngredientsDisponibles => new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
        };

        public static List<Pate> PatesDisponibles => new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
        };



        private static Pizza PizzaReine = new Pizza
        {
            Id = 1,
            Nom = "Reine",
            Ingredients = new List<Ingredient>
        {
            IngredientsDisponibles.First(i => i.Id == 7),
            IngredientsDisponibles.First(i => i.Id == 1),
            IngredientsDisponibles.First(i => i.Id == 2),
        },
            Pate = PatesDisponibles.First(i => i.Id == 1)

        };


        private static Pizza PizzaVege = new Pizza
        {
            Id = 2,
            Nom = "Vegan",
            Ingredients = new List<Ingredient>
        {
            IngredientsDisponibles.First(i => i.Id == 3),
            IngredientsDisponibles.First(i => i.Id == 1),
            IngredientsDisponibles.First(i => i.Id == 2),
            IngredientsDisponibles.First(i => i.Id == 4),
        },
            Pate = PatesDisponibles.First(i => i.Id == 2)

        };


        private static Pizza PizzaPoulet = new Pizza
        {
            Id = 3,
            Nom = "Pouleta",
            Ingredients = new List<Ingredient>
        {
            IngredientsDisponibles.First(i => i.Id == 3),
            IngredientsDisponibles.First(i => i.Id == 1),
            IngredientsDisponibles.First(i => i.Id == 8),
            IngredientsDisponibles.First(i => i.Id == 4),
        },
            Pate = PatesDisponibles.First(i => i.Id == 3)

        };

        public static List<Pizza> PizzaDisponibles => new List<Pizza>
        {

            PizzaPoulet,
            PizzaReine,
            PizzaVege


        };
        
}
}
