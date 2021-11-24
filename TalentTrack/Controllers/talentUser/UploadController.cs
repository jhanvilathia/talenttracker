using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentTrack.Models;

namespace TalentTrack.Controllers.talentUser
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult uploadArticle()
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult uploadArticle(tblArticle x)
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                tblPost p = new tblPost();

                var aid = Convert.ToInt32(Session["aid"]);
                p.artistId = aid;
                p.postType = "0";
                p.postStatus = "0";
                p.createdDate = DateTime.Now.Date.ToString();
                p.postTitle = x.postTitle;
                t.tblPosts.Add(p);
                t.SaveChanges();

                x.postID = t.tblPosts.Max(item => item.postId);
                x.imageURL = globalvar.addImage(x.articleImage);
                t.tblArticles.Add(x);
                t.SaveChanges();

                return RedirectToAction("artistArticle","Login");
            }
        }

        [HttpGet]
        public ActionResult uploadImage()
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult uploadImage(tblImage x)
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                tblPost p = new tblPost();

                var aid = Convert.ToInt32(Session["aid"]);
                p.artistId = aid;
                p.postType = "1";
                p.postStatus = "0";
                p.createdDate = DateTime.Now.Date.ToString();
                p.postTitle = x.postTitle;
                t.tblPosts.Add(p);
                t.SaveChanges();

                x.postId = t.tblPosts.Max(item => item.postId);
                x.imageURL = globalvar.addImage(x.artistImage);
                t.tblImages.Add(x);
                t.SaveChanges();

                return RedirectToAction("artistImage", "Login");
            }
        }

        [HttpGet]
        public ActionResult uploadVideo()
        {
            using (TalentTrackerM t=new TalentTrackerM())
            {
                return View();
            }
        }

        public ActionResult uploadVideo(tblVideo x)
        {
            using(TalentTrackerM t=new TalentTrackerM())
            {
                tblPost p = new tblPost();

                var aid = Convert.ToInt32(Session["aid"]);
                p.artistId = aid;
                p.postType = "2";
                p.postStatus = "0";
                p.createdDate = DateTime.Now.Date.ToString();
                p.postTitle = x.postTitle;
                t.tblPosts.Add(p);
                t.SaveChanges();

                x.postId = t.tblPosts.Max(item => item.postId);
                if(x.videoType==1)
                x.videoURL = globalvar.addVideo(x.artistVideo);
                t.tblVideos.Add(x);
                t.SaveChanges();

                return RedirectToAction("artistVideo", "Login");
            }
        }

    }
}