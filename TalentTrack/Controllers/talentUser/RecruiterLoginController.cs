using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class RecruiterLoginController : Controller
    {
        // GET: RecruiterLogin
        public ActionResult RecIndex()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");

                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecruiterLogin(tblRecruiter r)
        {
            TalentTrackerM t = new TalentTrackerM();

            tblRecruiter temp1 = t.tblRecruiters.Where(recinfo => recinfo.recemail==r.recemail && recinfo.recpassword==r.recpassword).SingleOrDefault();
            if(temp1==null)
            {
                ViewBag.logerror = "Invalid email address or password...";
                return View("RecIndex"); 
            }
            else
            {
                Session["remail"] = temp1.recemail;
                Session["rid"] = temp1.recruiterId;
                Session["rname"] = temp1.userName;
                Session["rprofile"] = temp1.image;
                return RedirectToAction("RecruiterProfile", "RecruiterLogin");
            }
        }

        public ActionResult RecruiterProfile()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                string x = Session["remail"].ToString();
                var r = t.tblRecruiters.Where(s => s.recemail.Equals(x)).SingleOrDefault();

                r.tblCity = t.tblCities.Where(citydata => citydata.cityId == r.cityId).SingleOrDefault();

                return View(r);
            }
        }

        [HttpGet]
        public ActionResult UpdateRecruiter()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(Session["rid"]);
                return View(t.tblRecruiters.Where(recinfo => recinfo.recruiterId == rid).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateRecruiter(tblRecruiter x)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(Session["rid"]);
                tblRecruiter x1 = t.tblRecruiters.FirstOrDefault(a => a.recruiterId == rid);
                if (x1 != null)
                {
                    x1.name = x.name;
                    x1.companyName = x.companyName;
                    x1.description = x.description;
                    x1.contactNo = x.contactNo;
                    x1.website = x.website;
                    t.Entry(x1).State = System.Data.Entity.EntityState.Modified;
                    t.SaveChanges();
                }
                return RedirectToAction("RecruiterProfile");
            }
        }

        [HttpGet]
        public ActionResult addRequirement()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                tblRequirement c = new tblRequirement();
                c.clist = t.tblCategories.ToList();
                return View(c);
            }
        }

        [HttpPost]
        public ActionResult addRequirement(tblRequirement req)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                int rid = Convert.ToInt32(Session["rid"]);
                req.recruiterId = rid;
                req.addedDate=DateTime.Now.Date;
                t.tblRequirements.Add(req);
                t.SaveChanges(); 
                return RedirectToAction("showRequirement");
            }
        }

        public ActionResult showRequirement()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(Session["rid"]);
                IEnumerable<tblRequirement> r = t.tblRequirements.Where(s => s.recruiterId == rid).ToList();

                foreach(var key in r)
                {
                    key.tblCategory = t.tblCategories.Where(catdata=>catdata.categoryId==key.categoryId).SingleOrDefault();
                    key.tblRecruiter = t.tblRecruiters.Where(reqdata => reqdata.recruiterId == rid).SingleOrDefault();

                    key.tblRequirementApplications = t.tblRequirementApplications.Where(x => x.requirementId == key.requirementId).ToList();

                    foreach(var x in key.tblRequirementApplications)
                    {
                        x.tblArtist = t.tblArtists.Where(y => y.artistId == x.artistId).FirstOrDefault();

                    }

                    //var reqid = Convert.ToInt32(requirementId);
                    //IEnumerable<tblRequirementApplication> req = t.tblRequirementApplications.Where(b => b.requirementId == reqid).ToList();
                    //foreach(var result in req)
                    //{
                    //    result.tblRequirement = t.tblRequirements.Where(x => x.requirementId == result.requirementId).SingleOrDefault();
                    //    result.tblArtist = t.tblArtists.Where(y => y.artistId == result.artistId).SingleOrDefault();
                    //}
                    //return View(req);

                }

                return View(r);
            }
        }

        [HttpGet]
        public ActionResult managePassword()
        {
            if (Session["rid"] != null)
            {
                using (TalentTrackerM t = new TalentTrackerM())
                {
                    var rid = Convert.ToInt32(Session["rid"]);
                    ViewBag.managePassword = t.tblRecruiters.Where(x => x.recruiterId == rid).ToList();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("RecruiterProfile");
            }
        }

        public int checkPassword(string currentPassword)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(Session["rid"]);
                tblRecruiter r = t.tblRecruiters.FirstOrDefault(x => x.recruiterId == rid);
                if (r.recpassword == currentPassword)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int changePassword(string newPassword)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(Session["rid"]);
                tblRecruiter r = t.tblRecruiters.FirstOrDefault(x => x.recruiterId == rid);
                r.recpassword = newPassword;
                t.SaveChanges();
                return 1;
            }
        }

        public ActionResult logout()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");

                Session.Clear();
                return RedirectToAction("RecIndex");
            }
        }

    }
}