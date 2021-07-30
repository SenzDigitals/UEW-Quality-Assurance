using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UEW_Quality_Assurance.Migrations
{
    public partial class addedSurveyForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegularStudent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    studentID = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    courseID = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lecturerID = table.Column<int>(type: "int", nullable: true),
                    Results = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegularStudent_Course_courseID",
                        column: x => x.courseID,
                        principalTable: "Course",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegularStudent_Lecturer_lecturerID",
                        column: x => x.lecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "lecturerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegularStudent_Student_studentID",
                        column: x => x.studentID,
                        principalTable: "Student",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SectionA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lecturerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SectionA_Lecturer_lecturerID",
                        column: x => x.lecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "lecturerID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegularStudent_courseID",
                table: "RegularStudent",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_RegularStudent_lecturerID",
                table: "RegularStudent",
                column: "lecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_RegularStudent_studentID",
                table: "RegularStudent",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionA_lecturerID",
                table: "SectionA",
                column: "lecturerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegularStudent");

            migrationBuilder.DropTable(
                name: "SectionA");
        }
    }
}
