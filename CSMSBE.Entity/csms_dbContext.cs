﻿using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.IdentityAccess;
using CSMS.Entity.IdentityExtensions;
using CSMS.Entity.IdentityExtensions.IdentityMapping;
using CSMS.Entity.Issues;
using CSMS.Entity.LogHistory;
using CSMS.Entity.SecurityMatrix;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CSMS.Entity
{
    public partial class csms_dbContext : IdentityDbContext<User, Role, string, UserClaim
        , UserRole, UserLogin, RoleClaim, UserTokens>
    {
        private readonly IConfiguration _configuration;
        public csms_dbContext()
        {
        }
        public csms_dbContext(DbContextOptions<csms_dbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost:5433;Database=csms;Username=speckle;Password=speckle;");
            }

        }
        #region
        public override DbSet<User> Users { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<SecurityMatrices> SecurityMatrix { get; set; }
        public DbSet<SecurityMatrix.Action> Action { get; set; }
        public DbSet<Screen> Screen { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TypeProject> TypeProject { get; set; }
        public DbSet<UserLoginLog> UserLoginLogs { get; set; }
        public DbSet<SomeTable> SomeTables { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<LogHistoryEntity> LogHistoryEntities { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Model> Models { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AspNetRefreshTokensMap());

            base.OnModelCreating(modelBuilder);
            #region core model builder

            modelBuilder.Entity<Screen>(entity =>
            {
                entity.ToTable("Screen", schema: "sys");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.ParentId)
                      .HasColumnName("parent_id");

                entity.HasOne(e => e.Parent)
                      .WithMany(p => p.Childrent)
                      .HasForeignKey(e => e.ParentId);

                entity.Property(e => e.Code)
                      .HasColumnName("code")
                      .IsRequired();

                entity.Property(e => e.Name)
                      .HasColumnName("name")
                      .IsRequired();

                entity.Property(e => e.Title)
                      .HasColumnName("title")
                      .IsRequired();

                entity.Property(e => e.Icon)
                      .HasColumnName("icon");

                entity.Property(e => e.Order)
                      .HasColumnName("order")
                      .IsRequired();

                entity.HasMany(e => e.SecurityMatrices)
                      .WithOne(sm => sm.Screen)
                      .HasForeignKey(sm => sm.ScreenId);
            });

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(e => e.User)
                .WithMany(e => e.UserClaims)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(e => e.Role)
                .WithMany(e => e.RoleClaims)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<SecurityMatrices>()
                .HasOne(e => e.Action)
                .WithMany(e => e.SecurityMatrices)
                .HasForeignKey(e => e.ActionId);

            modelBuilder.Entity<SecurityMatrices>()
                .HasOne(e => e.Screen)
                .WithMany(e => e.SecurityMatrices)
                .HasForeignKey(e => e.ScreenId);

            modelBuilder.Entity<SecurityMatrices>()
                .HasOne(e => e.Role)
                .WithMany(e => e.SecurityMatrices)
                .HasForeignKey(e => e.RoleId);
           
            modelBuilder.Entity<UserLogin>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLogins)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();
            modelBuilder.Entity<Issue>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Issue>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Issue>()
               .HasOne(i => i.User)
               .WithMany(u => u.Issues)
               .HasForeignKey(i => i.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.ProjectId)
                .IsRequired();

            modelBuilder.Entity<Comment>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Comment>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
               .HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Issue>()
                .HasMany(i => i.Comments)
                .WithOne(c => c.Issues)
                .HasForeignKey(c => c.IssueId);

            modelBuilder.Entity<Model>()
       .HasKey(i => i.Id);

            modelBuilder.Entity<Model>()
                .Property(m => m.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Project>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Project>()
                .Property(p => p.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Project>()
                .HasMany(u => u.Models)
                .WithOne(c => c.Project)
                .HasForeignKey(c => c.ProjectID);

            #endregion
        }
    }
}
