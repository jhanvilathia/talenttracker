namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblAdmin")]
    public partial class tblAdmin
    {
        [Key]
        public int adminId { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public string email { get; set; }

        public int? contactNo { get; set; }

        public string profile { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageData { get; set; }

    }
}
