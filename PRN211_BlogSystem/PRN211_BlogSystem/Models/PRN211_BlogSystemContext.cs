﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRN211_BlogSystem.Models
{
    public partial class PRN211_BlogSystemContext : DbContext
    {
        public PRN211_BlogSystemContext()
        {
        }

        public PRN211_BlogSystemContext(DbContextOptions<PRN211_BlogSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Feature> Features { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                              .SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("authorName");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(255)
                    .HasColumnName("metaTitle");

                entity.Property(e => e.NoView).HasColumnName("noView");

                entity.Property(e => e.Summary)
                    .HasMaxLength(255)
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.HasOne(d => d.AuthorNameNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AuthorName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Blog__authorName__31EC6D26");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Blogs)
                    .UsingEntity<Dictionary<string, object>>(
                        "BlogCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Blog_Cate__categ__3D5E1FD2"),
                        r => r.HasOne<Blog>().WithMany().HasForeignKey("BlogId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Blog_Cate__blogI__3C69FB99"),
                        j =>
                        {
                            j.HasKey("BlogId", "CategoryId");

                            j.ToTable("Blog_Category");

                            j.IndexerProperty<int>("BlogId").HasColumnName("blogId");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("categoryId");
                        });

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Blogs)
                    .UsingEntity<Dictionary<string, object>>(
                        "BlogTag",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Blog_Tag__tagId__37A5467C"),
                        r => r.HasOne<Blog>().WithMany().HasForeignKey("BlogId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Blog_Tag__blogId__36B12243"),
                        j =>
                        {
                            j.HasKey("BlogId", "TagId");

                            j.ToTable("Blog_Tag");

                            j.IndexerProperty<int>("BlogId").HasColumnName("blogId");

                            j.IndexerProperty<int>("TagId").HasColumnName("tagId");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("authorName");

                entity.Property(e => e.BlogId).HasColumnName("blogId");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createAt");

                entity.HasOne(d => d.AuthorNameNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AuthorName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__authorN__412EB0B6");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment__blogId__403A8C7D");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasMany(d => d.Features)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoleFeature",
                        l => l.HasOne<Feature>().WithMany().HasForeignKey("FeatureId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Role_Feat__featu__2F10007B"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Role_Feat__roleI__2E1BDC42"),
                        j =>
                        {
                            j.HasKey("RoleId", "FeatureId");

                            j.ToTable("Role_Feature");

                            j.IndexerProperty<int>("RoleId").HasColumnName("roleId");

                            j.IndexerProperty<int>("FeatureId").HasColumnName("featureId");
                        });
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .HasColumnName("displayName");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("lastLogin");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RegisterAt)
                    .HasColumnType("datetime")
                    .HasColumnName("registerAt");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Usernames)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__roleI__29572725"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("Username").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__usern__286302EC"),
                        j =>
                        {
                            j.HasKey("Username", "RoleId");

                            j.ToTable("User_Role");

                            j.IndexerProperty<string>("Username").HasMaxLength(100).IsUnicode(false).HasColumnName("username");

                            j.IndexerProperty<int>("RoleId").HasColumnName("roleId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
