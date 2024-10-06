using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SimplyBooks.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Favorite = table.Column<bool>(type: "boolean", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Sale = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "Favorite", "FirstName", "Image", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, "firstguy@faux.com", true, "Jack", "totallyrealimageurl.com", "Sparrow", 1 },
                    { 2, "johndoe@faux.com", false, "John", "imageurl1.com", "Doe", 2 },
                    { 3, "janedoe@faux.com", true, "Jane", "imageurl2.com", "Doe", 1 },
                    { 4, "lukesky@faux.com", false, "Luke", "imageurl3.com", "Skywalker", 1 },
                    { 5, "leiaorgana@faux.com", true, "Leia", "imageurl4.com", "Organa", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[,]
                {
                    { 1, "notmyemail@gmail.com", "MrThinCrisp" },
                    { 2, "theRealDoghBoy@gmail.com", "Jondoe" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Image", "Price", "Sale", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "A book about how to be a politely confused individual", "bookpictureurl.com", 2.4500000000000002, false, "uhhh, ah yes.", 1 },
                    { 2, 2, "Follow John Doe through a series of unexpected adventures.", "bookimage1.com", 15.99, true, "The Adventures of John Doe", 2 },
                    { 3, 3, "An inspiring tale of Jane Doe's journey to self-discovery.", "bookimage2.com", 12.75, false, "The Chronicles of Jane", 1 },
                    { 4, 4, "Explore the inner workings of the Force in this Jedi guide.", "bookimage3.com", 19.989999999999998, true, "The Force Within", 1 },
                    { 5, 5, "Leia Organa shares her insights on leadership and resilience.", "bookimage4.com", 22.5, false, "The Rebel's Guide to Leadership", 2 },
                    { 6, 2, "A thrilling mystery that will keep you on the edge of your seat.", "bookimage5.com", 10.99, true, "Mystery of the Unknown", 2 },
                    { 7, 3, "A heartfelt story of redemption and forgiveness.", "bookimage6.com", 18.199999999999999, false, "The Road to Redemption", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
