using Eni.Tp.Asp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eni.Tp.Asp.Controllers
{
    public class ChatController : Controller
    {

        private static List<Chat> listeChats = Chat.GetMeuteDeChats();
        // GET: ChatController
        public ActionResult Index()
        {
           
            return View(listeChats);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            var chat = listeChats.Where(x => x.Id == id).FirstOrDefault();

            if(chat != null)
            {
                return View(chat);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
           
        }

        // GET: ChatController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Chat chat = new Chat();
                    chat.Nom = collection["Nom"];
                    chat.Age =  int.Parse(collection["Age"]);
                    chat.Couleur = collection["Couleur"];
                    chat.Id = listeChats.Max(chat => chat.Id) + 1;

                    listeChats.Add(chat);
                  
                    RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatController/Edit/5
        public ActionResult Edit(int id)
        {
            var chat = listeChats.Where(x => x.Id == id).FirstOrDefault();

            if (chat != null)
            {
                return View(chat);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ChatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Chat chat = listeChats.Where(x => x.Id == id).FirstOrDefault();
                    chat.Nom = collection["Nom"];
                    chat.Age = int.Parse(collection["Age"]);
                    chat.Couleur = collection["Couleur"];
                   

                    

                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = listeChats.Where(x => x.Id == id).FirstOrDefault();

            if (chat != null)
            {
                return View(chat);

            }

            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                listeChats.Remove(listeChats.Where(x => x.Id == id).FirstOrDefault());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
