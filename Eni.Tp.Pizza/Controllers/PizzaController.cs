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


            ViewData["ingredients"] = Pizza.IngredientsDisponibles;
            ViewData["pates"] = Pizza.PatesDisponibles;
            return View();


        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {

            ViewData["ingredients"] = Pizza.IngredientsDisponibles;
            ViewData["pates"] = Pizza.PatesDisponibles;
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewData["ingredients"] = Pizza.IngredientsDisponibles;
                    ViewData["pates"] = Pizza.PatesDisponibles;

                    return View(pizza);

                }



                pizza.Ingredients = new List<Ingredient>();
                if (pizza.ListeIngIds != null)
                {
                    pizza.ListeIngIds.ForEach(id => pizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                }

                pizza.Pate = Pizza.PatesDisponibles.First(pate => pate.Id == pizza.PateId);

                pizza.Id = listePizzas.Max(chat => chat.Id) + 1;

                if (listePizzas.Any(p => p.Nom == pizza.Nom) ) {

                    ModelState.AddModelError(nameof(Pizza.Nom), "Le nom de la pizza doit être unique");
                    return View(pizza);
                }

                if(listePizzas.Select(p => p.ListeIngIds).Contains(pizza.ListeIngIds))
                {
                    ModelState.AddModelError(nameof(Pizza.Nom), "Une composition de pizza ne peut pas être similaire à une autre pizza");
                    return View(pizza);
                }


                
                listePizzas.Add(pizza);


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

            ViewData["ingredients"] = Pizza.IngredientsDisponibles;
            ViewData["pates"] = Pizza.PatesDisponibles;
            try
            {



                if (!ModelState.IsValid)
                {
                    ViewData["ingredients"] = Pizza.IngredientsDisponibles;
                    ViewData["pates"] = Pizza.PatesDisponibles;

                    return View(pizza);

                }



                if (listePizzas.Any(p => p.Nom == pizza.Nom && p.Id != pizza.Id))
                {

                    ModelState.AddModelError(nameof(Pizza.Nom), "Le nom de la pizza doit être unique");
                    return View(pizza);
                }

                if (listePizzas.Where(p=> pizza.Id != p.Id).Select(p => p.ListeIngIds).Any(c => c.SequenceEqual(pizza.ListeIngIds)))
                {
                    ModelState.AddModelError(nameof(Pizza.ListeIngIds), "Une composition de pizza ne peut pas être similaire à une autre pizza");
                    return View(pizza);
                }
                Pizza oldPizza = listePizzas.Where(x => x.Id == id).FirstOrDefault();
                mapper.Map(pizza, oldPizza);
                oldPizza.Ingredients = new List<Ingredient>();
                oldPizza.ListeIngIds.ForEach(id => oldPizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                oldPizza.Pate = Pizza.PatesDisponibles.First(pate => pate.Id == oldPizza.PateId);









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
