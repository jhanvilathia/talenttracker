namespace TalentTrack.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TalentTrackerM : DbContext
    {
        public TalentTrackerM()
            : base("name=TalentTrackerM")
        {
        }

        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblArticle> tblArticles { get; set; }
        public virtual DbSet<tblArtist> tblArtists { get; set; }
        public virtual DbSet<tblArtistCategory> tblArtistCategories { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblCity> tblCities { get; set; }
        public virtual DbSet<tblFollow> tblFollows { get; set; }
        public virtual DbSet<tblImage> tblImages { get; set; }
        public virtual DbSet<tblPost> tblPosts { get; set; }
        public virtual DbSet<tblPostComment> tblPostComments { get; set; }
        public virtual DbSet<tblPostLike> tblPostLikes { get; set; }
        public virtual DbSet<tblRecruiter> tblRecruiters { get; set; }
        public virtual DbSet<tblRequirement> tblRequirements { get; set; }
        public virtual DbSet<tblRequirementApplication> tblRequirementApplications { get; set; }
        public virtual DbSet<tblState> tblStates { get; set; }
        public virtual DbSet<tblVideo> tblVideos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.profile)
                .IsUnicode(false);

            modelBuilder.Entity<tblArticle>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblArticle>()
                .Property(e => e.imageURL)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<tblArtist>()
                .Property(e => e.registrationDT)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .Property(e => e.categoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblCity>()
                .Property(e => e.cityName)
                .IsUnicode(false);

            modelBuilder.Entity<tblImage>()
                .Property(e => e.imageURL)
                .IsUnicode(false);

            modelBuilder.Entity<tblPost>()
                .Property(e => e.postTitle)
                .IsUnicode(false);

            modelBuilder.Entity<tblPost>()
                .Property(e => e.postStatus)
                .IsUnicode(false);

            modelBuilder.Entity<tblPost>()
                .Property(e => e.createdDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblPost>()
                .Property(e => e.postType)
                .IsUnicode(false);

            modelBuilder.Entity<tblPostComment>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<tblPostComment>()
                .Property(e => e.createdDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.recpassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.recemail)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.companyName)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.website)
                .IsUnicode(false);

            modelBuilder.Entity<tblRecruiter>()
                .Property(e => e.registrationDate)
                .IsUnicode(false);

            modelBuilder.Entity<tblRequirement>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<tblRequirement>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblRequirementApplication>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tblState>()
                .Property(e => e.stateName)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.videoURL)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.duration)
                .IsUnicode(false);
        }
    }
}
