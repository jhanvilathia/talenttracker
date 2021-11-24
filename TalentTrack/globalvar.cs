using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace TalentTrack
{
    public class globalvar
    {
        public static string addImage(HttpPostedFileBase img)
        {
            string filename = Path.GetFileName(img.FileName);
            string fname = Path.GetFileName(img.FileName);

            filename = Path.Combine(HttpContext.Current.Server.MapPath("~/images/") + filename);
            img.SaveAs(filename);

            return fname;
        }

        public static string addVideo(HttpPostedFileBase vdo)
        {
            string filename = Path.GetFileName(vdo.FileName);
            string fname = Path.GetFileName(vdo.FileName);

            filename = Path.Combine(HttpContext.Current.Server.MapPath("~/videos/") + filename);
            vdo.SaveAs(filename);

            return fname;
        }
    }
}