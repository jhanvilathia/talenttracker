using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class ShowRequirementController : Controller
    {
        // GET: ShowRequirement
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult recruiterIndex(string companyName=null,int categoryId=0,string cityName=null)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                if(companyName!=null && categoryId!=0 && cityName!=null)
                {
                    var x = t.tblRequirements.Where(y => y.tblRecruiter.companyName.Contains(companyName) && y.categoryId == categoryId && y.tblRecruiter.tblCity.cityName.Contains(cityName)).ToList();
                    foreach (var key in x)
                    {
                        key.tblRecruiter = t.tblRecruiters.Where(rec => rec.recruiterId == key.recruiterId).SingleOrDefault();
                        key.tblCategory = t.tblCategories.Where(cat => cat.categoryId == key.categoryId).SingleOrDefault();
                        key.tblRecruiter.tblCity = t.tblCities.Where(city => city.cityId == key.tblRecruiter.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(x);
                }
                else if(companyName == null && categoryId != 0 && cityName == null)
                {
                    var x = t.tblRequirements.Where(y =>y.categoryId == categoryId).ToList();
                    foreach (var key in x)
                    {
                        key.tblRecruiter = t.tblRecruiters.Where(rec => rec.recruiterId == key.recruiterId).SingleOrDefault();
                        key.tblCategory = t.tblCategories.Where(cat => cat.categoryId == key.categoryId).SingleOrDefault();
                        key.tblRecruiter.tblCity = t.tblCities.Where(city => city.cityId == key.tblRecruiter.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(x);
                }
                else
                {
                    IEnumerable<tblRequirement> r = t.tblRequirements.ToList();
                    foreach (var key in r)
                    {
                        key.tblRecruiter = t.tblRecruiters.Where(rec => rec.recruiterId == key.recruiterId).SingleOrDefault();
                        key.tblCategory = t.tblCategories.Where(cat => cat.categoryId == key.categoryId).SingleOrDefault();
                        key.tblRecruiter.tblCity = t.tblCities.Where(city => city.cityId == key.tblRecruiter.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(r);
                }
                
            }
        }

        public ActionResult moreInfo(int requirementId)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var rid = Convert.ToInt32(requirementId);
                var r = t.tblRequirements.Where(req => req.requirementId == rid).FirstOrDefault();
                r.tblRecruiter = t.tblRecruiters.Where(a => a.recruiterId == r.recruiterId).SingleOrDefault();
                r.tblCategory = t.tblCategories.Where(cat => cat.categoryId == r.categoryId).SingleOrDefault();
                r.tblRecruiter.tblCity = t.tblCities.Where(city => city.cityId == r.tblRecruiter.cityId).SingleOrDefault();

                return View(r);
            }
        }

        public ActionResult applyJob(int requirementId,tblRequirementApplication r)
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                int aid = Convert.ToInt32(Session["aid"]);
                var rid = Convert.ToInt32(requirementId);
                r.artistId = aid;
                r.requirementId = rid;
                r.responseDate = DateTime.Now.Date;
                t.tblRequirementApplications.Add(r);
                t.SaveChanges();
                return RedirectToAction("recruiterIndex","ShowRequirement",new { ac="success" });
                //return JavaScript(alert("Your application added successfully"));
                //return Content("<script language='javascript' type='text/javascript'>window.onload = function () {alert('Your application added successfully');};</script>");


                //t.tblRequirementApplications.Where(req => req.requirementId == rid && req.artistId==aid).FirstOrDefault();


            }
        }

    }
}
