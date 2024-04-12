using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Razor.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuthorID1",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryID1",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CategoryID1",
                table: "Articles",
                newName: "CateID");

            migrationBuilder.RenameColumn(
                name: "AuthorID1",
                table: "Articles",
                newName: "AuID");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CategoryID1",
                table: "Articles",
                newName: "IX_Articles_CateID");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuthorID1",
                table: "Articles",
                newName: "IX_Articles_AuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuID",
                table: "Articles",
                column: "AuID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CateID",
                table: "Articles",
                column: "CateID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Authors_AuID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CateID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CateID",
                table: "Articles",
                newName: "CategoryID1");

            migrationBuilder.RenameColumn(
                name: "AuID",
                table: "Articles",
                newName: "AuthorID1");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_CateID",
                table: "Articles",
                newName: "IX_Articles_CategoryID1");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_AuID",
                table: "Articles",
                newName: "IX_Articles_AuthorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Authors_AuthorID1",
                table: "Articles",
                column: "AuthorID1",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryID1",
                table: "Articles",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
