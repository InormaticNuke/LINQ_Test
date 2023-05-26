using Proyecto_Locales_ManuelRengifo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Locales_ManuelRengifo.Controllers
{
    public class LocalesController : Controller
    {
        BasePruebaBDEntities conexion = new BasePruebaBDEntities();
        public ActionResult Index()
        {

            var lista = conexion.Locales.ToList();
            return View(lista);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Locales local = conexion.Locales.Find(id);

            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "IdLocal,NombreLocal,Direccion,Telefono")]Locales local)
        {
            if (!ModelState.IsValid)
            {
                conexion.Locales.Add(local);
                conexion.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Locales local = conexion.Locales.Find(id);

            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        public ActionResult Edit([Bind(Include = "IdLocal,NombreLocal,Direccion,Telefono")] Locales local)
        {
            if (ModelState.IsValid)
            {
                conexion.Entry(local).State = EntityState.Modified;
                conexion.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(local);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Locales local = conexion.Locales.Find(id);

            if (local == null)
            {
                return HttpNotFound();
            }
            return View(local);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Locales local = conexion.Locales.Find(id);
            conexion.Locales.Remove(local);
            conexion.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}