﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyList.Data.Contexts;

#nullable disable

namespace MyList.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220602191450_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApplicationRoleApplicationUser", b =>
                {
                    b.Property<Guid>("ApplicationUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationUsersId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("ApplicationRoleApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyList.Data.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("MyList.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Anime", b =>
                {
                    b.Property<Guid>("AnimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountEpisodes")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlobalScore")
                        .HasColumnType("int");

                    b.Property<string>("GlobalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelizeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimeID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Book", b =>
                {
                    b.Property<Guid>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlobalScore")
                        .HasColumnType("int");

                    b.Property<string>("GlobalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelizeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Film", b =>
                {
                    b.Property<Guid>("FilmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlobalScore")
                        .HasColumnType("int");

                    b.Property<string>("GlobalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelizeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Game", b =>
                {
                    b.Property<Guid>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameStudio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlobalScore")
                        .HasColumnType("int");

                    b.Property<string>("GlobalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelizeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Serial", b =>
                {
                    b.Property<Guid>("SerialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountEpisodes")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GlobalScore")
                        .HasColumnType("int");

                    b.Property<string>("GlobalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RelizeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserScore")
                        .HasColumnType("int");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Serial");
                });

            modelBuilder.Entity("MyList.Data.Models.Creators", b =>
                {
                    b.Property<Guid>("CreatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("AnimeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("BookID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FilmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SerialID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CreatorID");

                    b.HasIndex("AnimeID");

                    b.HasIndex("BookID");

                    b.HasIndex("FilmID");

                    b.HasIndex("SerialID");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.AnimeTag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AnimeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.HasIndex("AnimeID");

                    b.ToTable("AnimeTag");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.BookTag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.HasIndex("BookID");

                    b.ToTable("BookTag");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.FilmTag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FilmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.HasIndex("FilmID");

                    b.ToTable("FilmTag");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.GameTag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.HasIndex("GameID");

                    b.ToTable("GameTag");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.SerialTag", b =>
                {
                    b.Property<Guid>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SerialID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TagID");

                    b.HasIndex("SerialID");

                    b.ToTable("SerialTag");
                });

            modelBuilder.Entity("ApplicationRoleApplicationUser", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("ApplicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyList.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Anime", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany("Anime")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Book", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany("Books")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Film", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany("Films")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Game", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany("Games")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Serial", b =>
                {
                    b.HasOne("MyList.Data.Models.ApplicationUser", null)
                        .WithMany("Serials")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyList.Data.Models.Creators", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Anime", null)
                        .WithMany("Authors")
                        .HasForeignKey("AnimeID");

                    b.HasOne("MyList.Data.Models.ContentModels.Book", null)
                        .WithMany("Authors")
                        .HasForeignKey("BookID");

                    b.HasOne("MyList.Data.Models.ContentModels.Film", null)
                        .WithMany("Authors")
                        .HasForeignKey("FilmID");

                    b.HasOne("MyList.Data.Models.ContentModels.Serial", null)
                        .WithMany("Authors")
                        .HasForeignKey("SerialID");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.AnimeTag", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Anime", null)
                        .WithMany("Tags")
                        .HasForeignKey("AnimeID");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.BookTag", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Book", null)
                        .WithMany("Tags")
                        .HasForeignKey("BookID");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.FilmTag", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Film", null)
                        .WithMany("Tags")
                        .HasForeignKey("FilmID");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.GameTag", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Game", null)
                        .WithMany("Tags")
                        .HasForeignKey("GameID");
                });

            modelBuilder.Entity("MyList.Data.Models.Tags.SerialTag", b =>
                {
                    b.HasOne("MyList.Data.Models.ContentModels.Serial", null)
                        .WithMany("Tags")
                        .HasForeignKey("SerialID");
                });

            modelBuilder.Entity("MyList.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Anime");

                    b.Navigation("Books");

                    b.Navigation("Films");

                    b.Navigation("Games");

                    b.Navigation("Serials");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Anime", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Book", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Film", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Game", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyList.Data.Models.ContentModels.Serial", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
