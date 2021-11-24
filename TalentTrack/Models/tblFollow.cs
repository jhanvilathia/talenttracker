namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFollow")]
    public partial class tblFollow
    {
        [Key]
        public int followId { get; set; }

        public int? artistId { get; set; }

        public int? followerId { get; set; }

        public virtual tblArtist tblArtist { get; set; }
    }
}
