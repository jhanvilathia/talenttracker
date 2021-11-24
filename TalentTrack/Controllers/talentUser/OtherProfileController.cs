using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class OtherProfileController : Controller
    {
        // GET: OtheProfile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loadOtherProfile(int artistId)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(artistId);
                var a=t.tblArtists.Where(ar => ar.artistId == aid).SingleOrDefault();
                a.tblCity = t.tblCities.Where(c => c.cityId == a.cityId).SingleOrDefault();
                a.tblCategory = t.tblCategories.Where(cat => cat.categoryId == a.categoryId).SingleOrDefault();
                a.tblCity.tblState = t.tblStates.Where(s => s.stateId == a.tblCity.stateId).SingleOrDefault();

                var fid = Convert.ToInt32(Session["aid"]);

                ViewBag.opost = t.tblPosts.Count(c => c.artistId == aid);
                ViewBag.ofollowing = t.tblFollows.Count(f => f.followerId == aid);
                ViewBag.ofollowers = t.tblFollows.Count(f => f.artistId==aid);
                ViewBag.check= t.tblFollows.Where(x => x.followerId == fid && x.artistId == aid).SingleOrDefault();

                return View(a);
            }
        }

        public ActionResult loadOtherArticle(int artistId)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(artistId);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId == aid && s.postType == "0").ToList();
                foreach(var key in p)
                {
                    key.art = t.tblArticles.Where(article => article.postID == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult loadOtherImage(int artistId)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(artistId);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId == aid && s.postType == "1").ToList();
                foreach(var key in p)
                {
                    key.img = t.tblImages.Where(i => i.postId == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult loadOtherVideo(int artistId)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(artistId);
                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId == aid && s.postType == "2").ToList();
                foreach(var key in p)
                {
                    key.vdo = t.tblVideos.Where(v => v.postId == key.postId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult follow(int artistId)
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                var fid = Convert.ToInt32(Session["aid"]);
                var aid = Convert.ToInt32(artistId);

                tblFollow f = t.tblFollows.Where(x => x.followerId == fid && x.artistId==aid).SingleOrDefault();

                if(f!=null)
                {
                    var data = t.tblFollows.Where(x => x.followerId == fid && x.artistId == aid).SingleOrDefault();
                    t.tblFollows.Remove(data);
                    t.SaveChanges();
                }
                else
                {
                    tblFollow x = new tblFollow();
                    x.artistId = aid;
                    x.followerId = fid;
                    t.tblFollows.Add(x);
                    t.SaveChanges();
                }

                return RedirectToAction("loadOtherProfile","OtherProfile",new { artistId = artistId });
            }
        }
    }
}