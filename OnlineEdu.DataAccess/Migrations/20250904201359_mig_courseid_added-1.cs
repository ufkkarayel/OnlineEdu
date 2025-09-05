using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_courseid_added1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntities_CourseCategories_CategoryID",
                table: "BaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntities_CategoryID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BaseEntities");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BaseEntities");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CourseCategories",
                        principalColumn: "CourseCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryID",
                table: "Courses",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "BaseEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntities",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BaseEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BaseEntities",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "BaseEntities",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntities_CategoryID",
                table: "BaseEntities",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntities_CourseCategories_CategoryID",
                table: "BaseEntities",
                column: "CategoryID",
                principalTable: "CourseCategories",
                principalColumn: "CourseCategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
