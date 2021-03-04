using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoSQLtestia.Data;
using NoSQLtestia.Models;
using System.Threading.Tasks;


namespace NoSQLtestia.Controllers
{
    public class JasenetController : Controller
    {
        private readonly IJasenetRepo _dataAccessProvider = new JasenetRepo();

        public async Task<ActionResult> Index()
        {
            IEnumerable<Jasenet> jasenets = await _dataAccessProvider.GetJasenet();
            return View(jasenets);
        }


        // GET: Jasenet/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jasenet jasenet = await _dataAccessProvider.GetJasenet(id);
            if (jasenet == null)
            {
                return HttpNotFound();
            }
            return View(jasenet);
        }

        // GET: Jasenet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jasenet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Etunimi,Sukunimi,Osoite,Postinumero,Sahkoposti,Puhelin,JasenyydenAlkuPvm")] Jasenet jasenet)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Add(jasenet);
                return RedirectToAction("Index");
            }

            return View(jasenet);
        }

        // GET: Jasenet/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jasenet jasenet = await _dataAccessProvider.GetJasenet(id);
            if (jasenet == null)
            {
                return HttpNotFound();
            }
            return View(jasenet);
        }

        // POST: Jasenet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Etunimi,Sukunimi,Osoite,Postinumero,Sahkoposti,Puhelin,JasenyydenAlkuPvm")] Jasenet jasenet)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Update(jasenet);
                return RedirectToAction("Index");
            }
            return View(jasenet);
        }

        // GET: Jasenet/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jasenet jasenet = await _dataAccessProvider.GetJasenet(id);
            if (jasenet == null)
            {
                return HttpNotFound();
            }
            return View(jasenet);
        }

        // POST: Jasenet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _dataAccessProvider.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
