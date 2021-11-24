using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult RegisterIndex()
        {
            //return View();
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");
                return View();
            }
        }

        [HttpPost]
        public ActionResult registerArtist(tblArtist x)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                x.image = globalvar.addImage(x.imgdata);
                t.tblArtists.Add(x);
                t.SaveChanges();
                return RedirectToAction("RegisterIndex","Register",new { ac="login" });
            }
        }

        public string checkUsername(string username)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                tblArtist temp = t.tblArtists.Where(ar => ar.userName == username).SingleOrDefault();
                if(temp==null)
                {
                    string msg = "Username is available";
                    return msg;
                }
                else
                {
                    string msg = "This user is already registered";
                    return msg;
                }
                
            }
        }

        [HttpPost]
        public ActionResult registerRecruiter(tblRecruiter x)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                x.image = globalvar.addImage(x.imgdata);
                t.tblRecruiters.Add(x);
                t.SaveChanges();
                return RedirectToAction("RegisterIndex", "Register", new { ac="login" });
            }
        }

        public string checkRecUsername(string username)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                tblRecruiter temp = t.tblRecruiters.Where(ar => ar.userName == username).SingleOrDefault();
                if (temp == null)
                {
                    string msg = "Username is available";
                    return msg;
                }
                else
                {
                    string msg = "This user is already registered";
                    return msg;
                }

            }
        }
    }
}