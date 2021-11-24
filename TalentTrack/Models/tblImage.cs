namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblImage")]
    public partial class tblImage
    {
        [Key]
        public int imageId { get; set; }

        public int? postId { get; set; }

        public string imageURL { get; set; }

        public int? categoryId { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblPost tblPost { get; set; }

        [NotMapped]
        public HttpPostedFileBase artistImage { get; set; }

        [NotMapped]
        public string postTitle { get; set; }
    }
}
