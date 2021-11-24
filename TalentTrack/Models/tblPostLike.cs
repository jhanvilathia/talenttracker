namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPostLike")]
    public partial class tblPostLike
    {
        [Key]
        public int postLikeId { get; set; }

        public int? artistId { get; set; }

        public int? postId { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        public virtual tblPost tblPost { get; set; }
    }
}
