using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult DisplayArtist()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var c = t.tblArtists.ToList();

                foreach(var x in c)
                {
                    x.tblCategory = t.tblCategories.Where(p => p.categoryId == x.categoryId).SingleOrDefault();
                    x.tblCity = t.tblCities.Where(citydata => citydata.cityId == x.cityId).SingleOrDefault();
                }
                return View(c);
            }

        }

        public ActionResult artistInfo(int artistId)
        {
            using (TalentTrackerM t = new TalentTrackerM()) 
            {
                int aid = Convert.ToInt32(artistId);
                var a = t.tblArtists.Where(x => x.artistId == aid).SingleOrDefault();

                a.tblCategory = t.tblCategories.Where(c => c.categoryId == a.categoryId).SingleOrDefault();
                a.tblCity = t.tblCities.Where(ct => ct.cityId == a.cityId).SingleOrDefault();


                IEnumerable<tblPost> p = t.tblPosts.Where(s => s.artistId == aid && s.postType == "0").ToList();
                ViewBag.article = p;
                foreach (var key in p)
                {
                    key.art = t.tblArticles.Where(article => article.postID == key.postId).SingleOrDefault();
                }

                IEnumerable<tblPost> i = t.tblPosts.Where(s => s.artistId == aid && s.postType == "1").ToList();
                ViewBag.image = i;
                foreach (var key in i)
                {
                    key.img = t.tblImages.Where(imagedata => imagedata.postId == key.postId).SingleOrDefault();
                }

                IEnumerable<tblPost> v = t.tblPosts.Where(s => s.artistId == aid && s.postType == "2").ToList();
                ViewBag.video = v;
                foreach (var key in v)
                {
                    key.vdo = t.tblVideos.Where(video => video.postId == key.postId).SingleOrDefault();
                }


                return View(a);
            }
        }

    }
}
