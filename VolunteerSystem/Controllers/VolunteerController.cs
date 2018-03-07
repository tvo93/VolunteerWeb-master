using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VolunteerSystem.DAL;
using VolunteerSystem.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace VolunteerSystem.Controllers
{
    public class VolunteerController : Controller
    {
        private CompanyContext db = new CompanyContext();

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }
        // GET: Volunteer
        [Authorize]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var volunteers = from s in db.Volunteers
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    volunteers = volunteers.OrderByDescending(s => s.LastName);
                    break;
             
                default:
                    volunteers = volunteers.OrderBy(s => s.LastName);
                    break;
            }

            // decide how many pages display at a time
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(volunteers.ToPagedList(pageNumber, pageSize));

        }
        // GET: Volunteer/Create
        // Create roles 
        // only admin and manager can create new volunteer
        [Authorize(Users ="admin@gmail.com, manager@gmail.com")] 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,BirthDate,EnrollmentDate")] Volunteer volunteer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Volunteers.Add(volunteer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
              {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(volunteer);
        }

        // GET: Volunteer/Edit/5

        [Authorize(Users = "admin@gmail.com, manager@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var volunteerToUpdate = db.Volunteers.Find(id);
            if (TryUpdateModel(volunteerToUpdate, "",
               new string[] { "LastName", "FirstMidName", "EnrollmentDate" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                      {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(volunteerToUpdate);
        }

        // only admin can delete
        [Authorize(Users = "admin@gmail.com")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return HttpNotFound();
            }
            return View(volunteer);
        }




        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
    
            public ActionResult Delete(int id)
            {
                try
                {
                    Volunteer volunteer = db.Volunteers.Find(id);
                    db.Volunteers.Remove(volunteer);
                    db.SaveChanges();
                }
            catch (RetryLimitExceededException)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
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
