namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRequirementApplication")]
    public partial class tblRequirementApplication
    {
        [Key]
        public int requirementappId { get; set; }

        public int? requirementId { get; set; }

        public int? artistId { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? responseDate { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        public virtual tblRequirement tblRequirement { get; set; }
    }
}
