namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("tblArtist")]
    public partial class tblArtist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArtist()
        {
            tblArtistCategories = new HashSet<tblArtistCategory>();
            tblFollows = new HashSet<tblFollow>();
            tblPosts = new HashSet<tblPost>();
            tblPostComments = new HashSet<tblPostComment>();
            tblPostLikes = new HashSet<tblPostLike>();
            tblRequirementApplications = new HashSet<tblRequirementApplication>();
        }

        [Key]
        public int artistId { get; set; }

        public int? categoryId { get; set; }

        public string image { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Required(ErrorMessage ="Please enter username e.g. John Doe")]
        [StringLength(50,MinimumLength =3)]
        public string userName { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        public int? contactNo { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "text")]
        public string website { get; set; }

        public int? cityId { get; set; }

        [StringLength(50)]
        public string registrationDT { get; set; }

        public int? status { get; set; }

        [NotMapped]
        public HttpPostedFileBase imgdata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArtistCategory> tblArtistCategories { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblCity tblCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFollow> tblFollows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPost> tblPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPostComment> tblPostComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPostLike> tblPostLikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRequirementApplication> tblRequirementApplications { get; set; }
    }
}
