#region Namespaces
using MercuryHealth.Models;
using MercuryHealth.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

namespace MercuryHealth.Web.Controllers
{

    public class MyMetricsController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyMetrics
        public ActionResult Calculate()
        {
            var myMetricsVm = new MyMetricsViewModel();
            // Comment
            var currentUserId = User.Identity;
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            myMetricsVm.MemberProfile = db.Users
                .Include("MemberProfile")
                .Where(u => u.Id == currentUser.Id)
                .First()
                .MemberProfile;

            return View(myMetricsVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(MyMetricsViewModel myMetricsVm)
        {
            return View(myMetricsVm);
        }

    }

}