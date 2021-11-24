using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: Recruiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult displayRequirement()
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                var r = t.tblRequirements.ToList();
                foreach(var key in r)
                {
                    key.tblRecruiter = t.tblRecruiters.Where(x=>x.recruiterId==key.recruiterId).SingleOrDefault();
                    key.tblCategory = t.tblCategories.Where(c => c.categoryId == key.categoryId).SingleOrDefault();
                    key.tblRecruiter.tblCity = t.tblCities.Where(y => y.cityId == key.tblRecruiter.tblCity.cityId).SingleOrDefault();
                }
                return View(r);
            }
        }

        public ActionResult requirementInfo(int recruiterId)
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                //var rid = Convert.ToInt32(requirementId);
                //var r = t.tblRequirementApplications.Where(x => x.requirementId == rid).SingleOrDefault();

                //r.tblRequirement = t.tblRequirements.Where(y => y.requirementId == rid && y.recruiterId==r.tblRequirement.recruiterId).SingleOrDefault();
                //r.tblArtist = t.tblArtists.Where(z => z.artistId == r.artistId).SingleOrDefault();

                var rid = Convert.ToInt32(recruiterId);
                var r = t.tblRecruiters.Where(y => y.recruiterId == rid).SingleOrDefault();
                r.tblCity = t.tblCities.Where(c => c.cityId == r.cityId).SingleOrDefault();

                IEnumerable<tblRequirement> x = t.tblRequirements.Where(a => a.recruiterId == rid).ToList();
                ViewBag.req = x;
                foreach(var key in x)
                {
                    key.tblCategory = t.tblCategories.Where(c => c.categoryId == key.categoryId).SingleOrDefault();
                    foreach(var b in key.tblRequirementApplications)
                    {
                        ViewBag.app = b;
                        b.tblRequirement = t.tblRequirements.Where(a => a.requirementId == b.requirementId).SingleOrDefault();
                        b.tblArtist = t.tblArtists.Where(c => c.artistId == b.artistId).SingleOrDefault();

                    }
                }

                //IEnumerable<tblRequirementApplication> ap=t.tblRequirementApplications.Where(a=>a.requirementId==)
                
                return View(r);
            }
        }
    }
}