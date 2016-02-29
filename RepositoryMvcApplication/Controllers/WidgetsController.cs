using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryMvcApplication.Entities;
using RepositoryMvcApplication;
using Repository;
using RepositoryMvcApplication.Models;
using AutoMapper;
using RepositoryMvcApplication.Trasformation;
using RedisCache;
using RepositoryMvcApplication.Cache;

namespace RepositoryMvcApplication.Controllers
{
    public class WidgetsController : Controller
    {
        private DataTestEntities db = new DataTestEntities();
        private IMultiplexer mul = null;

        public WidgetsController()
        {

               mul = new Multiplexer();
        }

        //
        // GET: /Widgets/
        
        public ActionResult Index()
        {

            return View(mul.GetWidgetsList());
        }

        //
        // GET: /Widgets/Details/5

        public ActionResult Details(int id = 1)
        {
            return View(mul.GetWidget(id));
        }

        //
        // GET: /Widgets/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Widgets/Create

        [HttpPost]
        public ActionResult Create(Widget widget)
        {
            if (ModelState.IsValid)
            {
                mul.AddWidget(widget);

                return RedirectToAction("Index");
            }

            return View(widget);
        }
        
        //
        // GET: /Widgets/Edit/5

        public ActionResult Edit(int id = 0)
        {
             Widget w = mul.GetWidget(id);
            if (w == null)
            {        
                return HttpNotFound();
            }

            return View(w);
        }
        
        //
        // POST: /Widgets/Edit/5

        [HttpPost]
        public ActionResult Edit(Widget widget)
        {
            if (ModelState.IsValid)
            {
                  mul.UpdateWidget(widget);
       
                return RedirectToAction("Index");
            }
            
            return View(widget);
        }

        //
        // GET: /Widgets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Widget widget = mul.GetWidget(id);

            if (widget == null)
            
                return HttpNotFound();
            mul.DeleteWidget(widget);
            
            return View(widget);
        }

        //
        // POST: /Widgets/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Widget widget = mul.GetWidget(id);

            if (widget != null)
            {
                mul.DeleteWidget(widget);
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
         
    }
} 