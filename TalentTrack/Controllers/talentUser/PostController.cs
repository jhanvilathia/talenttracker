using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult showArticle()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                IEnumerable<tblPost> p = t.tblPosts.Where(post => post.postType == "0").ToList();
                foreach(var key in p)
                {
                    key.art = t.tblArticles.Where(article => article.postID == key.postId).SingleOrDefault();
                    key.tblArtist = t.tblArtists.Where(a => a.artistId == key.artistId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult articleMoreInfo(int postid)
        {
           using (TalentTrackerM t = new TalentTrackerM())
            {

                var p = t.tblPosts.Where(post => post.postType == "0").FirstOrDefault();
                var pid = Convert.ToInt32(postid);

                p.art = t.tblArticles.Where(article => article.postID == pid).SingleOrDefault();
                p.tblArtist = t.tblArtists.Where(artistdata => artistdata.artistId == p.artistId).SingleOrDefault();

                foreach(var x in p.tblPostComments)
                {
                    
                    x.tblPost = t.tblPosts.Where(c => c.postId == pid).SingleOrDefault();
                    x.tblArtist = t.tblArtists.Where(a => a.artistId == x.artistId).SingleOrDefault();
                }

                foreach(var l in p.tblPostLikes)
                {
                    l.tblPost = t.tblPosts.Where(x => x.postId == l.postId).SingleOrDefault();
                    ViewBag.like = t.tblPostLikes.Count(y => y.postId == l.postId);

                }

                return View(p);
            }
        }

        public ActionResult LikeArticle(int postid)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                var pid = Convert.ToInt32(postid);

                tblPostLike l = t.tblPostLikes.Where(x => x.postId == pid && x.artistId == aid).SingleOrDefault();
                if(l!=null)
                {
                    var data= t.tblPostLikes.Where(x => x.postId == pid && x.artistId == aid).SingleOrDefault();
                    t.tblPostLikes.Remove(data);
                    t.SaveChanges();
                }
                else
                {
                    tblPostLike x = new tblPostLike();
                    x.artistId = aid;
                    x.postId = pid;
                    t.tblPostLikes.Add(x);
                    t.SaveChanges();
                }
                return RedirectToAction("articleMoreInfo","Post",new { postId=postid });
            }
        }

        [HttpPost]
        public ActionResult articleComment(int postid,tblPostComment p)
        {
            if(Session["aid"]!=null)
            {
                using (TalentTrackerM t = new TalentTrackerM())
                {
                    var aid = Convert.ToInt32(Session["aid"]);
                    var pid = Convert.ToInt32(postid);

                    p.artistId = aid;
                    p.postId = pid;
                    p.createdDate = DateTime.Now.Date.ToString();

                    t.tblPostComments.Add(p);
                    t.SaveChanges();
                }
                return RedirectToAction("articleMoreInfo", "Post", new { postid });
            }
            else
            {
                return RedirectToAction("Index", "Login",new { ac="error" });
            }



        }

        public ActionResult showVideo()
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                IEnumerable<tblPost> p = t.tblPosts.Where(post => post.postType == "2").ToList();
                foreach (var key in p)
                {
                    key.vdo = t.tblVideos.Where(v => v.postId == key.postId).SingleOrDefault();
                    key.tblArtist = t.tblArtists.Where(a => a.artistId == key.artistId).SingleOrDefault();
                }
                return View(p);
            }
        }

        public ActionResult videoMoreInfo(int postid)
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                
                var p = t.tblPosts.Where(post => post.postType == "2").FirstOrDefault();
                var pid = Convert.ToInt32(postid);

                p.vdo = t.tblVideos.Where(video => video.postId == pid).SingleOrDefault();
                p.tblArtist = t.tblArtists.Where(a => a.artistId == p.artistId).SingleOrDefault();

                foreach (var x in p.tblPostComments)
                {

                    x.tblPost = t.tblPosts.Where(c => c.postId == pid).SingleOrDefault();
                    x.tblArtist = t.tblArtists.Where(a => a.artistId == x.artistId).SingleOrDefault();
                }

                foreach (var l in p.tblPostLikes)
                {
                    l.tblPost = t.tblPosts.Where(x => x.postId == l.postId).SingleOrDefault();
                    ViewBag.like = t.tblPostLikes.Count(y => y.postId == l.postId);

                }
                return View(p);
            }
        }

        public ActionResult LikeVideo(int postid)
        {
            using (TalentTrackerM t = new TalentTrackerM())
            {
                var aid = Convert.ToInt32(Session["aid"]);
                var pid = Convert.ToInt32(postid);

                tblPostLike l = t.tblPostLikes.Where(x => x.postId == pid && x.artistId == aid).SingleOrDefault();
                if (l != null)
                {
                    var data = t.tblPostLikes.Where(x => x.postId == pid && x.artistId == aid).SingleOrDefault();
                    t.tblPostLikes.Remove(data);
                    t.SaveChanges();
                }
                else
                {
                    tblPostLike x = new tblPostLike();
                    x.artistId = aid;
                    x.postId = pid;
                    t.tblPostLikes.Add(x);
                    t.SaveChanges();
                }
                return RedirectToAction("videoMoreInfo", "Post", new { postId = postid });
            }
        }

        [HttpPost]
        public ActionResult videoComment(int postid, tblPostComment p)
        {
            if (Session["aid"] != null)
            {
                using (TalentTrackerM t = new TalentTrackerM())
                {
                    var aid = Convert.ToInt32(Session["aid"]);
                    var pid = Convert.ToInt32(postid);

                    p.artistId = aid;
                    p.postId = pid;
                    p.createdDate = DateTime.Now.Date.ToString();

                    t.tblPostComments.Add(p);
                    t.SaveChanges();
                }
                return RedirectToAction("videoMoreInfo", "Post", new { postid });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { ac = "error" });
            }
        }

    } 
}


//foreach(var key in p)
//{
//    key.art = t.tblArticles.Where(article => article.postID == key.postId).SingleOrDefault();
//    key.tblArtist = t.tblArtists.Where(a => a.artistId == key.artistId).SingleOrDefault();
//}

//using (TalentTrackerM t = new TalentTrackerM())
//{
//    ar.tblPost = t.tblPosts.Where(artdata => artdata.postId == ar.postID).SingleOrDefault();
//    ar.tblPost.tblArtist = t.tblArtists.Where(artistdata => artistdata.artistId == ar.tblPost.artistId).SingleOrDefault();

//    return View();
//}