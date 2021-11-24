namespace TalentTrack.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPost")]
    public partial class tblPost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPost()
        {
            tblArticles = new HashSet<tblArticle>();
            tblImages = new HashSet<tblImage>();
            tblPostComments = new HashSet<tblPostComment>();
            tblPostLikes = new HashSet<tblPostLike>();
            tblVideos = new HashSet<tblVideo>();
        }

        [Key]
        public int postId { get; set; }

        [StringLength(50)]
        public string postTitle { get; set; }

        [StringLength(50)]
        public string postStatus { get; set; }

        [StringLength(50)]
        public string createdDate { get; set; }

        [StringLength(50)]
        public string postType { get; set; }

        [NotMapped]
        public tblArticle art;

        [NotMapped]
        public tblVideo vdo;

        [NotMapped]
        public tblImage img;

        [NotMapped]
        public tblPostComment cmt;
        public int? artistId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblArticle> tblArticles { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblImage> tblImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPostComment> tblPostComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPostLike> tblPostLikes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVideo> tblVideos { get; set; }
    }
}
