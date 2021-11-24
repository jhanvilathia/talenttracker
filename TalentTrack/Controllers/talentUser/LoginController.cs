using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblArtist a)
        {
            TalentTrackerM t = new TalentTrackerM();
            
                tblArtist temp = t.tblArtists.Where(x => x.email.Equals(a.email) && x.password.Equals(a.password)).SingleOrDefault();
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");
                if (temp==null)
                {
                    ViewBag.error = "Invalid email address or password...";
                    return RedirectToAction("Index","Login",new { ac="logerr" });
                }
                else
                {
                    Session["email"] = temp.email;
                    Session["aid"] = temp.artistId;
                    Session["uname"] = temp.userName;
                    Session["profile"] = temp.image;
                    return RedirectToAction("profile", "Login");
                }
            
        }

        public ActionResult profile()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                string x = Session["email"].ToString();
                var a = t.tblArtists.Where(s=>s.email.Equals(x)).SingleOrDefault();
                
                a.tblCategory = t.tblCategories.Where(p => p.categoryId == a.categoryId).SingleOrDefault();
                a.tblCity = t.tblCities.Where(citydata => citydata.cityId == a.cityId).SingleOrDefault();
                a.tblCity.tblState = t.tblStates.Where(state => state.stateId == a.tblCity.stateId).SingleOrDefault();

                ViewBag.post = t.tblPosts.Count(c=>c.artistId==a.artistId);
                ViewBag.following = t.tblFollows.Count(f => f.followerId == a.artistId);
                ViewBag.followers = t.tblFollows.Count(f => f.artistId == a.artistId);

                return View(a);
            }
        }

        public ActionResult artistImage()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId==aid && s.postType=="1").ToList();

                foreach(var key in p)
                {
                        key.img = t.tblImages.Where(imagedata => imagedata.postId == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult artistArticle()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId==aid && s.postType=="0").ToList();

                foreach (var key in p)
                {
                        key.art = t.tblArticles.Where(article => article.postID == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult artistVideo()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId == aid && s.postType == "2").ToList();

                foreach(var key in p)
                {
                    key.vdo = t.tblVideos.Where(video => video.postId == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }
         
        [HttpGet]
        public ActionResult UpdateArtist()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                return View(t.tblArtists.Where(artistinfo=>artistinfo.artistId==aid).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult UpdateArtist(tblArtist x)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                tblArtist x1 = t.tblArtists.FirstOrDefault(a => a.artistId == aid);
                if(x1!=null)
                {
                    x1.name = x.name;
                    x1.DOB = x.DOB;
                    x1.description = x.description;
                    x1.contactNo = x.contactNo;
                    x1.website = x.website;
                    t.Entry(x1).State = System.Data.Entity.EntityState.Modified;
                    t.SaveChanges();
                }
               return RedirectToAction("profile");
            }
        }

        [HttpGet]
        public ActionResult managePassword()
        {
            if(Session["aid"]!=null)
            {
                using (TalentTrackerM t = new TalentTrackerM())
                {
                    var aid = Convert.ToInt32(Session["aid"]);
                    ViewBag.managePassword = t.tblArtists.Where(x => x.artistId == aid).ToList();
                    return View();
                }
            }
            else
            {
                return RedirectToAction("profile");
            }    
        }

        //[HttpPost]
        //public ActionResult managePassword(tblArtist a)
        //{
        //    using(TalentTrackerM t=new TalentTrackerM())
        //    {
        //        var aid = Convert.ToInt32(Session["aid"]);
        //        tblArtist a1 = t.tblArtists.FirstOrDefault(x => x.artistId == aid);
        //        if(a1!=null)
        //        {

        //        }
        //        return RedirectToAction("");
        //    }
        //    return RedirectToAction("profile");
        //}

        public int checkPassword(string currentPassword)
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                tblArtist a = t.tblArtists.FirstOrDefault(x => x.artistId == aid);
                if(a.password==currentPassword)
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
            using(TalentTrackerM t=new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                tblArtist a = t.tblArtists.FirstOrDefault(x => x.artistId == aid);
                a.password = newPassword;
                t.SaveChanges();
                return 1;
            }
        }

        public ActionResult logout()
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");

                Session.Clear();
                return RedirectToAction("Index");
            }
            
        }

        // GET: Login
        public ActionResult Index()
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                var catdata = t.tblCategories.ToList();
                ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");

                var citydata = t.tblCities.ToList();
                ViewBag.city = new SelectList(citydata, "cityId", "cityName");

                return View();
            }
            
        }

        public ActionResult artistIndex(string name=null,int categoryId=0,string cityName=null)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                if(name!=null && categoryId!=0 && cityName!=null) 
                {
                    var x = t.tblArtists.Where(y => y.name.Contains(name) && y.categoryId==categoryId && y.tblCity.cityName.Contains(cityName)).ToList();
                    foreach (var key in x)
                    {
                        key.tblCategory = t.tblCategories.Where(ar => ar.categoryId == key.categoryId).SingleOrDefault();
                        key.tblCity = t.tblCities.Where(cdata => cdata.cityId == key.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(x);
                }
                else if (name == null && categoryId != 0 && cityName == null)
                {
                    var x = t.tblArtists.Where(y => y.categoryId == categoryId).ToList();
                    foreach (var key in x)
                    {
                        key.tblCategory = t.tblCategories.Where(ar => ar.categoryId == key.categoryId).SingleOrDefault();
                        key.tblCity = t.tblCities.Where(cdata => cdata.cityId == key.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(x);
                }
                else
                {
                    IEnumerable<tblArtist> a = t.tblArtists.ToList();
                    foreach (var key in a)
                    {
                        key.tblCategory = t.tblCategories.Where(ar => ar.categoryId == key.categoryId).SingleOrDefault();
                        key.tblCity = t.tblCities.Where(cdata => cdata.cityId == key.cityId).SingleOrDefault();
                        var catdata = t.tblCategories.ToList();
                        ViewBag.category = new SelectList(catdata, "categoryId", "categoryName");
                    }
                    return View(a);
                }

                
            }
        }

    }
}
