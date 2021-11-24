namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblArtistCategory")]
    public partial class tblArtistCategory
    {
        [Key]
        public int artistCategoryId { get; set; }

        public int? artistId { get; set; }

        public int? categoryId { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}
