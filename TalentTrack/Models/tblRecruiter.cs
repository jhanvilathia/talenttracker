namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblRecruiter")]
    public partial class tblRecruiter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRecruiter()
        {
            tblRequirements = new HashSet<tblRequirement>();
        }

        [Key]
        public int recruiterId { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? cityId { get; set; }

        public int? contactNo { get; set; }

        public string image { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string recpassword { get; set; }

        [StringLength(50)]
        public string recemail { get; set; }

        [StringLength(50)]
        public string companyName { get; set; }

        [Column(TypeName = "text")]
        public string website { get; set; }

        [StringLength(50)]
        public string registrationDate { get; set; }

        public int? status { get; set; }

        public virtual tblCity tblCity { get; set; }

        [NotMapped]
        public HttpPostedFileBase imgdata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRequirement> tblRequirements { get; set; }
    }
}
