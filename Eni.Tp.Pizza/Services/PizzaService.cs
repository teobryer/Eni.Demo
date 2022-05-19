using Eni.TP_Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eni.TP_Pizza.Services
{
    public class PizzaService : IPizzaService
    {
        public void ajouterPizza()
        {
            throw new NotImplementedException();
        }

        public List<Pizza> recupererListePizza()
        {
            return Pizza.PizzaDisponibles;
        }
    }
}
