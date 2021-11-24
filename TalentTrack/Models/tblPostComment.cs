namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPostComment")]
    public partial class tblPostComment
    {
        [Key]
        public int postCommentId { get; set; }

        public int? artistId { get; set; }

        public int? postId { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        [StringLength(50)]
        public string createdDate { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        public virtual tblPost tblPost { get; set; }
    }
}
