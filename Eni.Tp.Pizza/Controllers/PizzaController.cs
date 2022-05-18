using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eni.TP_Pizza.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eni.TP_Pizza.Controllers
{
    public class PizzaController : Controller
    {

        private readonly IMapper mapper;
        public PizzaController(IMapper myMapper)
        {
            this.mapper = myMapper;
        }
        private static List<Pizza> listePizzas = Pizza.PizzaDisponibles;
        // GET: PizzaController
        public ActionResult Index()
        {
            return View(listePizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            var pizza = listePizzas.First(p => p.Id == id);

            if (pizza != null)
            {
                return View(pizza);
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {


            ViewData["ingredients"] = Pizza.IngredientsDisponibles ;
            ViewData["pates"] = Pizza.PatesDisponibles;
            return View();


        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    pizza.Ingredients = new List<Ingredient>();
                    pizza.ListeIngIds.ForEach(id => pizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                    pizza.Pate = Pizza.PatesDisponibles.First(pate => pate.Id == pizza.PateId);
                   
                    pizza.Id = listePizzas.Max(chat => chat.Id) + 1;
                    listePizzas.Add(pizza);
                    RedirectToAction("Index");
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = listePizzas.First(p => p.Id == id);
            ViewData["ingredients"] = Pizza.IngredientsDisponibles;
            ViewData["pates"] = Pizza.PatesDisponibles;



            if (pizza != null)
            {
                pizza.ListeIngIds = pizza.Ingredients.Select(i => i.Id).ToList();
                pizza.PateId = pizza.Pate.Id;
                return View(pizza);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pizza pizza)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pizza oldPizza = listePizzas.Where(x => x.Id == id).FirstOrDefault();
                    mapper.Map(pizza, oldPizza);
                    oldPizza.Ingredients = new List<Ingredient>();
                    oldPizza.ListeIngIds.ForEach(id => oldPizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                    oldPizza.Pate = Pizza.PatesDisponibles.First(pate => pate.Id == oldPizza.PateId);

                






                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = listePizzas.First(p => p.Id == id);

            if (pizza != null)
            {
                return View(pizza);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pizza pizza)
        {

            var pizzaToDelete = listePizzas.First(p => p.Id == id);
            try
            {
                listePizzas.Remove(pizzaToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
