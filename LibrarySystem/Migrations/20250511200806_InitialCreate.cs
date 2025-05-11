using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AvailableBooks = table.Column<int>(type: "int", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RemovedBooks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LostBook = table.Column<int>(type: "int", nullable: false),
                    WornOutBook = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedBooks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RemovedBooks_Books_ID",
                        column: x => x.ID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookRecords_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRecords_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "AvailableBooks", "PageCount", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("06aeceb1-b588-4eb2-aed6-821402a1e850"), "J.D. Salinger", 7, 277, 7, "The Catcher in the Rye" },
                    { new Guid("086c8b1f-04ef-4db5-9765-aa7b1fe3a4fa"), "J.R.R. Tolkien", 6, 310, 6, "The Hobbit" },
                    { new Guid("09c65208-b180-4d78-9ec1-843a38e1fcc9"), "Cormac McCarthy", 6, 287, 6, "The Road" },
                    { new Guid("0db925b6-9dc7-4b3b-865d-65b5f60675b3"), "Ray Bradbury", 7, 194, 7, "Fahrenheit 451" },
                    { new Guid("0eff9311-d04e-4a6a-9b39-3130d6f0df0b"), "James Clear", 14, 320, 14, "Atomic Habits" },
                    { new Guid("10860db3-9123-4e46-a6b4-5181b6aee70d"), "Fyodor Dostoevsky", 7, 671, 7, "Crime and Punishment" },
                    { new Guid("11ab52c9-43d9-4f69-9f96-8e2b11890b8f"), "Charlotte Brontë", 9, 532, 9, "Jane Eyre" },
                    { new Guid("273db004-798b-407e-b192-6509209b2b3a"), "Mary Shelley", 8, 280, 8, "Frankenstein" },
                    { new Guid("3e4241c7-c1b7-4ac1-91e9-aab5b90f0690"), "Herman Melville", 4, 635, 4, "Moby Dick" },
                    { new Guid("495fc7c7-557d-43af-82a2-8438d2c6f4e9"), "Alex Michaelides", 10, 336, 10, "The Silent Patient" },
                    { new Guid("4f801f25-99e0-4e3f-9237-5dba58cc1d46"), "Paulo Coelho", 12, 208, 12, "The Alchemist" },
                    { new Guid("55796e04-24bf-4fd6-b32b-9a20d0f54ddd"), "George Orwell", 9, 328, 9, "1984" },
                    { new Guid("58653711-b6b7-4b1b-8c26-45523d12b24f"), "Yuval Noah Harari", 11, 443, 11, "Sapiens" },
                    { new Guid("8d306ef6-1376-4536-8676-1df4e0e0b41b"), "Michelle Obama", 7, 448, 7, "Becoming" },
                    { new Guid("8fe01454-6ecb-43d6-a326-7ce7d74f2221"), "Stephen King", 10, 447, 10, "The Shining" },
                    { new Guid("916ad347-f822-4650-bbed-544dc1f5bff8"), "Harper Lee", 5, 281, 5, "To Kill a Mockingbird" },
                    { new Guid("9ab6a213-ffa2-436f-9098-6c63a81a7f3d"), "Markus Zusak", 9, 552, 9, "The Book Thief" },
                    { new Guid("a5659583-afcf-4d74-bb55-700aaebc5add"), "Frank Herbert", 10, 688, 10, "Dune" },
                    { new Guid("a647c522-3c84-47b0-b345-f235588d74ca"), "F. Scott Fitzgerald", 10, 180, 10, "The Great Gatsby" },
                    { new Guid("ab4f3d51-e392-4a4b-a0eb-e6ea5e02b447"), "Charles Duhigg", 13, 371, 13, "The Power of Habit" },
                    { new Guid("b320f6dc-dfd7-4d7d-aa1e-7227ef55c5bd"), "Jane Austen", 8, 279, 8, "Pride and Prejudice" },
                    { new Guid("b899c390-6f62-42a3-b3f4-729005d8bf59"), "Tara Westover", 8, 352, 8, "Educated" },
                    { new Guid("bffd2e62-289c-429c-88e5-b2d296948db2"), "Bram Stoker", 6, 418, 6, "Dracula" },
                    { new Guid("c0e9c35c-b3fe-4eeb-8214-b0a3f59b6132"), "Andy Weir", 11, 369, 11, "The Martian" },
                    { new Guid("ef512f0e-4069-4b8a-a424-e3a4c99bf861"), "Aldous Huxley", 5, 268, 5, "Brave New World" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ID", "Email", "FirstName", "RegistrationDate", "SecondName", "isAdmin" },
                values: new object[,]
                {
                    { new Guid("686c2eea-a853-4e8d-b89f-24880d85c46f"), "john.doe@example.com", "John", new DateTime(2025, 5, 11, 20, 8, 6, 319, DateTimeKind.Utc).AddTicks(9794), "Doe", false },
                    { new Guid("9f947f58-69c2-4229-8227-c5296b5c8e4b"), "jane.smith@example.com", "Jane", new DateTime(2025, 5, 11, 20, 8, 6, 319, DateTimeKind.Utc).AddTicks(9798), "Smith", false },
                    { new Guid("c6b47ac0-c5a1-44f6-9920-85cc435e1a75"), "alice.johnson@example.com", "Alice", new DateTime(2025, 5, 11, 20, 8, 6, 319, DateTimeKind.Utc).AddTicks(9801), "Johnson", true },
                    { new Guid("fd5b7bff-e07e-44bc-a43d-35598942d4f7"), "tom.jones@example.com", "Tom", new DateTime(2025, 5, 11, 20, 8, 6, 319, DateTimeKind.Utc).AddTicks(9799), "Jones", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRecords_BookID",
                table: "BookRecords",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookRecords_ProfileID",
                table: "BookRecords",
                column: "ProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRecords");

            migrationBuilder.DropTable(
                name: "RemovedBooks");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
