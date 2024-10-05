namespace SimplyBooks;
    using Microsoft.EntityFrameworkCore;
    using SimplyBooks.Models;

public class SimplyBooksDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }


    public SimplyBooksDbContext(DbContextOptions<SimplyBooksDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Email = "firstguy@faux.com", Favorite = true, FirstName = "Jack", LastName = "Sparrow", Image = "totallyrealimageurl.com", UserId = 1 },
            new Author { Id = 2, Email = "johndoe@faux.com", Favorite = false, FirstName = "John", LastName = "Doe", Image = "imageurl1.com", UserId = 2 },
            new Author { Id = 3, Email = "janedoe@faux.com", Favorite = true, FirstName = "Jane", LastName = "Doe", Image = "imageurl2.com", UserId = 1 },
            new Author { Id = 4, Email = "lukesky@faux.com", Favorite = false, FirstName = "Luke", LastName = "Skywalker", Image = "imageurl3.com", UserId = 1 },
            new Author { Id = 5, Email = "leiaorgana@faux.com", Favorite = true, FirstName = "Leia", LastName = "Organa", Image = "imageurl4.com", UserId = 2 }
            );
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, AuthorId = 1, Title = "uhhh, ah yes.", Image = "bookpictureurl.com", Price = 2.45, Sale = false, UserId = 1, Description = "A book about how to be a politely confused individual" },
            new Book { Id = 2, AuthorId = 2, Title = "The Adventures of John Doe", Image = "bookimage1.com", Price = 15.99, Sale = true, UserId = 2, Description = "Follow John Doe through a series of unexpected adventures." },
            new Book { Id = 3, AuthorId = 3, Title = "The Chronicles of Jane", Image = "bookimage2.com", Price = 12.75, Sale = false, UserId = 1, Description = "An inspiring tale of Jane Doe's journey to self-discovery." },
            new Book { Id = 4, AuthorId = 4, Title = "The Force Within", Image = "bookimage3.com", Price = 19.99, Sale = true, UserId = 1, Description = "Explore the inner workings of the Force in this Jedi guide." },
            new Book { Id = 5, AuthorId = 5, Title = "The Rebel's Guide to Leadership", Image = "bookimage4.com", Price = 22.50, Sale = false, UserId = 2, Description = "Leia Organa shares her insights on leadership and resilience." },
            new Book { Id = 6, AuthorId = 2, Title = "Mystery of the Unknown", Image = "bookimage5.com", Price = 10.99, Sale = true, UserId = 2, Description = "A thrilling mystery that will keep you on the edge of your seat." },
            new Book { Id = 7, AuthorId = 3, Title = "The Road to Redemption", Image = "bookimage6.com", Price = 18.20, Sale = false, UserId = 1, Description = "A heartfelt story of redemption and forgiveness." }

            );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "MrThinCrisp", Email = "notmyemail@gmail.com" },
            new User { Id = 2, UserName = "Jondoe", Email = "theRealDoghBoy@gmail.com" }
            );

        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}