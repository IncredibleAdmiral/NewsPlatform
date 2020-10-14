﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsTestPlatform.Data;

namespace NewsTestPlatform.Migrations
{
    [DbContext(typeof(PlatformContext))]
    [Migration("20201014124252_risk")]
    partial class risk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewsTestPlatform.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDataTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.NewsTopics", b =>
                {
                    b.Property<Guid>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NewsId", "TopicName");

                    b.HasIndex("TopicName");

                    b.ToTable("NewsTopics");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Annotation")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("NewsId")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.PostsTopics", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PostId", "TopicName");

                    b.HasIndex("TopicName");

                    b.ToTable("PostsTopics");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.Topic", b =>
                {
                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TopicName");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("NewsTestPlatform.Data.News", b =>
                {
                    b.HasOne("NewsTestPlatform.Data.Author", "Author")
                        .WithMany("News")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewsTestPlatform.Data.NewsTopics", b =>
                {
                    b.HasOne("NewsTestPlatform.Data.News", "News")
                        .WithMany("NewsTopics")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsTestPlatform.Data.Topic", "Topic")
                        .WithMany("NewsTopics")
                        .HasForeignKey("TopicName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewsTestPlatform.Data.Post", b =>
                {
                    b.HasOne("NewsTestPlatform.Data.Author", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsTestPlatform.Data.News", "News")
                        .WithOne("Post")
                        .HasForeignKey("NewsTestPlatform.Data.Post", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewsTestPlatform.Data.PostsTopics", b =>
                {
                    b.HasOne("NewsTestPlatform.Data.Post", "Post")
                        .WithMany("PostsTopics")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsTestPlatform.Data.Topic", "Topic")
                        .WithMany("PostsTopics")
                        .HasForeignKey("TopicName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
