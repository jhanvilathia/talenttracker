namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRequirement")]
    public partial class tblRequirement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblRequirement()
        {
            tblRequirementApplications = new HashSet<tblRequirementApplication>();
        }

        [Key]
        public int requirementId { get; set; }

        public int? recruiterId { get; set; }

        public int? categoryId { get; set; }

        [Column(TypeName = "text")]
        public string title { get; set; }

        public int? experience { get; set; }

        public int? salary { get; set; }

        [Column(TypeName = "date")]
        public DateTime? addedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? closingDate { get; set; }

        public int? status { get; set; }

        [Column(TypeName ="text")]
        public string description { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblRecruiter tblRecruiter { get; set; }

        [NotMapped]
        public IEnumerable<tblCategory> clist { get; set; }

        [NotMapped]
        public tblRequirementApplication app;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRequirementApplication> tblRequirementApplications { get; set; }
    }
}
