using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamRecording.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacultyRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyRoomType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfEnrolling = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamActivities",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FacultyRoomId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfExam = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamActivities", x => new { x.StudentId, x.CourseId, x.FacultyRoomId });
                    table.ForeignKey(
                        name: "FK_ExamActivities_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamActivities_FacultyRooms_FacultyRoomId",
                        column: x => x.FacultyRoomId,
                        principalTable: "FacultyRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamActivities_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FacultyRooms",
                columns: new[] { "Id", "FacultyRoomType", "Location", "Name", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, 2, "Location1", "Room1", 15 },
                    { 2, 1, "Location2", "Room2", 25 },
                    { 3, 1, "Location3", "Room3", 30 }
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Billy", "Bils" },
                    { 2, "Mendy", "Moore" },
                    { 3, "Jeny", "Jens" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfEnrolling", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 2, 22, 14, 3, 426, DateTimeKind.Local).AddTicks(7018), "John", "Doe" },
                    { 2, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4770), "Jony", "Jonies" },
                    { 3, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4816), "Mili", "Miee" },
                    { 4, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4821), "Richi", "Rich" },
                    { 5, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4824), "Lilly", "Lee" },
                    { 6, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4827), "Mili", "Mo" },
                    { 7, new DateTime(2021, 2, 2, 22, 14, 3, 431, DateTimeKind.Local).AddTicks(4830), "Lolita", "Lolis" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 33, "Programming", 1 },
                    { 4, 15, "Design", 1 },
                    { 5, 17, "Software Testing", 1 },
                    { 2, 22, "Digital Marketing", 2 },
                    { 3, 12, "Information Security Management System", 2 },
                    { 6, 11, "Computer Networks", 3 },
                    { 7, 25, "Data Science", 3 }
                });

            migrationBuilder.InsertData(
                table: "ExamActivities",
                columns: new[] { "CourseId", "FacultyRoomId", "StudentId", "DateOfExam", "Id", "StudentGrade" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(3680), 1, 10 },
                    { 1, 1, 2, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4460), 2, 8 },
                    { 1, 1, 3, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4487), 3, 8 },
                    { 4, 2, 4, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4490), 4, 7 },
                    { 4, 2, 5, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4493), 5, 8 },
                    { 5, 3, 6, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4496), 6, 9 },
                    { 5, 3, 7, new DateTime(2021, 2, 2, 22, 14, 3, 433, DateTimeKind.Local).AddTicks(4499), 7, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessorId",
                table: "Courses",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamActivities_CourseId",
                table: "ExamActivities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamActivities_FacultyRoomId",
                table: "ExamActivities",
                column: "FacultyRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamActivities");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "FacultyRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
