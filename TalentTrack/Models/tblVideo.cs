namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblVideo")]
    public partial class tblVideo
    {
        [Key]
        public int videoId { get; set; }

        public int? postId { get; set; }

        public string videoURL { get; set; }

        public int? videoType { get; set; }

        [Column(TypeName = "text")]
        public string duration { get; set; }

        public int? categoryId { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblPost tblPost { get; set; }

        [NotMapped]
        public HttpPostedFileBase artistVideo { get; set; }

        [NotMapped]
        public string postTitle { get; set; }
    }
}
