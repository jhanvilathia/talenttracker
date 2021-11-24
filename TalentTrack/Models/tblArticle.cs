namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblArticle")]
    public partial class tblArticle
    {
        [Key]
        public int articleId { get; set; }

        public int? postID { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public string imageURL { get; set; }

        public int? categoryID { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblPost tblPost { get; set; }

        [NotMapped]
        public HttpPostedFileBase articleImage { get; set; }

        [NotMapped]
        public string postTitle { get; set; }
    }
}
