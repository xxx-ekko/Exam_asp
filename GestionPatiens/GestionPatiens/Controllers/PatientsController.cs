using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace GestionPatiens.Controllers
{
    public class PatientsController : Controller
    {
        private PatientContext db = new PatientContext();

        // GET: Patients
        public ActionResult Index(string nom, string prenom, string email, string tel, DateTime? dateNaissance, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var patients = db.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(nom))
            {
                patients = patients.Where(p => p.NomPatient.Contains(nom));
            }

            if (!string.IsNullOrEmpty(prenom))
            {
                patients = patients.Where(p => p.PrenomPatient.Contains(prenom));
            }

            if (!string.IsNullOrEmpty(email))
            {
                patients = patients.Where(p => p.EmailPatient.Contains(email));
            }

            if (!string.IsNullOrEmpty(tel))
            {
                patients = patients.Where(p => p.TelPatient.Contains(tel));
            }

            if (dateNaissance.HasValue)
            {
                patients = patients.Where(p => p.DateNaissancePatient == dateNaissance.Value);
            }

            patients = patients.OrderBy(p => p.NomPatient).ToPagedList(pageNumber, pageSize);
            return View(patients);
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPatient,NomPatient,PrenomPatient,AdressePatient,EmailPatient,TelPatient,DateNaissancePatient")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPatient,NomPatient,PrenomPatient,AdressePatient,EmailPatient,TelPatient,DateNaissancePatient")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
