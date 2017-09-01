#region Namespaces
using MercuryHealth.Models;
using MercuryHealth.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
#endregion

namespace MercuryHealth.Web.Controllers
{

    public class MemberProfileController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: MemberProfile/Edit
        public ActionResult Edit()
        {
            var currentUserId = User.Identity;
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            var query = db.Users
                .Include("MemberProfile")
                .Where(u => u.Id == currentUser.Id)
                .First();

            return View(query);
        }

        // POST: MemberProfile/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity;
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                var query = db.Users
                    .Include("MemberProfile")
                    .Where(u => u.Id == currentUser.Id)
                    .First();
                query.MemberProfile = user.MemberProfile;

                db.MemberProfiles.Add(query.MemberProfile);
                db.Entry(query.MemberProfile).State = EntityState.Added;
                db.Entry(query).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View(user);
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