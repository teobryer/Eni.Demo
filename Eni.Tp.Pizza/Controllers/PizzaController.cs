using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eni.TP_Pizza.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eni.TP_Pizza.Services;

namespace Eni.TP_Pizza.Controllers
{
    public class PizzaController : Controller
    {

        private readonly IMapper mapper;

        private readonly IPizzaService pizzaService;
        private readonly IPateService pateService;
        private readonly IIngredientService ingredientService;
        public PizzaController(IMapper myMapper, IIngredientService ingredientService, IPizzaService pizzaService, IPateService pateService)
        {
            this.mapper = myMapper;
            this.pizzaService = pizzaService;
            this.ingredientService = ingredientService;
            this.pateService = pateService;
        }
        //private static List<Pizza> listePizzas = pizzaService.recupererListePizza();
        // GET: PizzaController
        public ActionResult Index()
        {
            return View(pizzaService.recupererListePizza());
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            var pizza = pizzaService.recupererListePizza().First(p => p.Id == id);

            if (pizza != null)
            {
                return View(pizza);
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            InitListesViewData();
            return View();


        }

        private void InitListesViewData()
        {
            ViewData["ingredients"] = ingredientService.recupererListeIngredients();
            ViewData["pates"] = pateService.recupererListePates();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {

            InitListesViewData();
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewData["ingredients"] = ingredientService.recupererListeIngredients();
                    ViewData["pates"] = pateService.recupererListePates();

                    return View(pizza);

                }



                pizza.Ingredients = new List<Ingredient>();
                if (pizza.ListeIngIds != null)
                {
                    pizza.ListeIngIds.ForEach(id => pizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                }

                pizza.Pate = pateService.recupererListePates().First(pate => pate.Id == pizza.PateId);

                pizza.Id = pizzaService.recupererListePizza().Max(chat => chat.Id) + 1;

                if (pizzaService.recupererListePizza().Any(p => p.Nom == pizza.Nom) ) {

                    ModelState.AddModelError(nameof(Pizza.Nom), "Le nom de la pizza doit être unique");
                    return View(pizza);
                }

                if (pizzaService.recupererListePizza().Select(p => p.ListeIngIds).Any(c => c.SequenceEqual(pizza.ListeIngIds)))
                {
                    ModelState.AddModelError(nameof(Pizza.Nom), "Une composition de pizza ne peut pas être similaire à une autre pizza");
                    return View(pizza);
                }



                pizzaService.recupererListePizza().Add(pizza);


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
            var pizza = pizzaService.recupererListePizza().First(p => p.Id == id);
            InitListesViewData();



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

            InitListesViewData();
            try
            {
                


                if (!ModelState.IsValid)
                {
                  

                    return View(pizza);

                }



                if (pizzaService.recupererListePizza().Any(p => p.Nom == pizza.Nom && p.Id != pizza.Id))
                {

                    ModelState.AddModelError(nameof(Pizza.Nom), "Le nom de la pizza doit être unique");
                    return View(pizza);
                }

                if (pizzaService.recupererListePizza().Where(p=> pizza.Id != p.Id).Select(p => p.ListeIngIds).Any(c => c.SequenceEqual(pizza.ListeIngIds)))
                {
                    ModelState.AddModelError(nameof(Pizza.ListeIngIds), "Une composition de pizza ne peut pas être similaire à une autre pizza");
                    return View(pizza);
                }
                Pizza oldPizza = pizzaService.recupererListePizza().Where(x => x.Id == id).FirstOrDefault();
                mapper.Map(pizza, oldPizza);
                oldPizza.Ingredients = new List<Ingredient>();
                oldPizza.ListeIngIds.ForEach(id => oldPizza.Ingredients.Add(Pizza.IngredientsDisponibles.First(ing => ing.Id == id)));
                oldPizza.Pate = pateService.recupererListePates().First(pate => pate.Id == oldPizza.PateId);









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
            var pizza = pizzaService.recupererListePizza().First(p => p.Id == id);

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

            var pizzaToDelete = pizzaService.recupererListePizza().First(p => p.Id == id);
            try
            {
                pizzaService.recupererListePizza().Remove(pizzaToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
