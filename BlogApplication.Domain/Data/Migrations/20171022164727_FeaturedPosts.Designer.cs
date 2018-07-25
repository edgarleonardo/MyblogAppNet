﻿// <auto-generated />
using BlogApplication.Domain.Data;
using BlogApplication.Domain.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BlogApplication.Domain.Data.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20171022164727_FeaturedPosts")]
    partial class FeaturedPosts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("Npgsql:ValueGeneratedOnAdd", true)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssetType");

                    b.Property<int>("DownloadCount");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<long>("Length");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("ProfileId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.BlogPost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Image")
                        .HasMaxLength(160);

                    b.Property<bool>("IsFeatured");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("PostViews");

                    b.Property<int>("ProfileId");

                    b.Property<DateTime>("Published");

                    b.Property<float>("Rating");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(450);

                    b.Property<string>("ImgSrc")
                        .HasMaxLength(160);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("ParentId");

                    b.Property<int>("ProfileId");

                    b.Property<int>("Rank");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.CustomField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomKey")
                        .IsRequired()
                        .HasMaxLength(140);

                    b.Property<int>("CustomType");

                    b.Property<string>("CustomValue");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("ParentId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.HasKey("Id");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.PostCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogPostId");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Avatar")
                        .HasMaxLength(160);

                    b.Property<string>("Bio")
                        .HasMaxLength(4000);

                    b.Property<string>("BlogTheme")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("IdentityName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Image")
                        .HasMaxLength(160);

                    b.Property<bool>("IsAdmin");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Logo")
                        .HasMaxLength(160);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160);

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.Asset", b =>
                {
                    b.HasOne("BlogApplication.Domain.Data.Domain.Profile")
                        .WithMany("Assets")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.BlogPost", b =>
                {
                    b.HasOne("BlogApplication.Domain.Data.Domain.Profile", "Profile")
                        .WithMany("BlogPosts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlogApplication.Domain.Data.Domain.PostCategory", b =>
                {
                    b.HasOne("BlogApplication.Domain.Data.Domain.BlogPost", "BlogPost")
                        .WithMany("PostCategories")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlogApplication.Domain.Data.Domain.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
