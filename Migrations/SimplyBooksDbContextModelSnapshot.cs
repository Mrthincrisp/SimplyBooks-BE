﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimplyBooks;

#nullable disable

namespace SimplyBooks.Migrations
{
    [DbContext(typeof(SimplyBooksDbContext))]
    partial class SimplyBooksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SimplyBooks.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Favorite")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "firstguy@faux.com",
                            Favorite = true,
                            FirstName = "Jack",
                            Image = "totallyrealimageurl.com",
                            LastName = "Sparrow",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "johndoe@faux.com",
                            Favorite = false,
                            FirstName = "John",
                            Image = "imageurl1.com",
                            LastName = "Doe",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "janedoe@faux.com",
                            Favorite = true,
                            FirstName = "Jane",
                            Image = "imageurl2.com",
                            LastName = "Doe",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "lukesky@faux.com",
                            Favorite = false,
                            FirstName = "Luke",
                            Image = "imageurl3.com",
                            LastName = "Skywalker",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            Email = "leiaorgana@faux.com",
                            Favorite = true,
                            FirstName = "Leia",
                            Image = "imageurl4.com",
                            LastName = "Organa",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SimplyBooks.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<bool>("Sale")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "A book about how to be a politely confused individual",
                            Image = "bookpictureurl.com",
                            Price = 2.4500000000000002,
                            Sale = false,
                            Title = "uhhh, ah yes.",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "Follow John Doe through a series of unexpected adventures.",
                            Image = "bookimage1.com",
                            Price = 15.99,
                            Sale = true,
                            Title = "The Adventures of John Doe",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "An inspiring tale of Jane Doe's journey to self-discovery.",
                            Image = "bookimage2.com",
                            Price = 12.75,
                            Sale = false,
                            Title = "The Chronicles of Jane",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Description = "Explore the inner workings of the Force in this Jedi guide.",
                            Image = "bookimage3.com",
                            Price = 19.989999999999998,
                            Sale = true,
                            Title = "The Force Within",
                            UserId = 1
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            Description = "Leia Organa shares her insights on leadership and resilience.",
                            Image = "bookimage4.com",
                            Price = 22.5,
                            Sale = false,
                            Title = "The Rebel's Guide to Leadership",
                            UserId = 2
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Description = "A thrilling mystery that will keep you on the edge of your seat.",
                            Image = "bookimage5.com",
                            Price = 10.99,
                            Sale = true,
                            Title = "Mystery of the Unknown",
                            UserId = 2
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            Description = "A heartfelt story of redemption and forgiveness.",
                            Image = "bookimage6.com",
                            Price = 18.199999999999999,
                            Sale = false,
                            Title = "The Road to Redemption",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("SimplyBooks.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "notmyemail@gmail.com",
                            UserName = "MrThinCrisp"
                        },
                        new
                        {
                            Id = 2,
                            Email = "theRealDoghBoy@gmail.com",
                            UserName = "Jondoe"
                        });
                });

            modelBuilder.Entity("SimplyBooks.Models.Author", b =>
                {
                    b.HasOne("SimplyBooks.Models.User", null)
                        .WithMany("Authors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimplyBooks.Models.Book", b =>
                {
                    b.HasOne("SimplyBooks.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimplyBooks.Models.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimplyBooks.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("SimplyBooks.Models.User", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
