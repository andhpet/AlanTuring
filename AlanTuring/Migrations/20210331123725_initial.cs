using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlanTuring.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    parentID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    accessibility = table.Column<bool>(type: "bit", nullable: false),
                    childID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Folders__90658CB819BFF475", x => x.parentID);
                });

            migrationBuilder.CreateTable(
                name: "Group_ConsistsOf_Students",
                columns: table => new
                {
                    students_ID = table.Column<int>(type: "int", nullable: true),
                    Groups_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student_Participate_Lessons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: false),
                    lessons_ID = table.Column<int>(type: "int", nullable: false),
                    students_ID = table.Column<int>(type: "int", nullable: false),
                    mark = table.Column<int>(type: "int", nullable: true),
                    attendance = table.Column<bool>(type: "bit", nullable: true),
                    Students_Participate_Lessons_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Students_Participate_Lessons_pk", x => new { x.ID, x.paths_ID, x.courses_ID, x.declarative_Lessons_ID, x.lessons_ID, x.students_ID });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    firstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    lastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    picture = table.Column<byte[]>(type: "image", nullable: true),
                    phone = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: true),
                    cv = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    folder_parentID = table.Column<int>(type: "int", nullable: true),
                    folder_childID = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    desciption = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    accessibility = table.Column<bool>(type: "bit", nullable: true),
                    content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Files__folder_pa__160F4887",
                        column: x => x.folder_parentID,
                        principalTable: "Folders",
                        principalColumn: "parentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    courses_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Courses_pk", x => new { x.ID, x.paths_ID });
                    table.UniqueConstraint("AK_Courses_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Courses__paths_I__52593CB8",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Graduations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    graduations_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk", x => new { x.ID, x.paths_ID });
                    table.ForeignKey(
                        name: "FK__Graduatio__paths__4D94879B",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<decimal>(type: "money", nullable: false),
                    position = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK__Employees__id__778AC167",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<decimal>(type: "money", nullable: false),
                    purpose = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    receiver_id = table.Column<int>(type: "int", nullable: false),
                    sender_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.id);
                    table.ForeignKey(
                        name: "FK__Finances__receiv__2EDAF651",
                        column: x => x.receiver_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Finances__sender__2FCF1A8A",
                        column: x => x.sender_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    hourlyRate = table.Column<decimal>(type: "money", nullable: false),
                    speciality = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.id);
                    table.ForeignKey(
                        name: "FK__Lecturers__id__628FA481",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<short>(type: "smallint", nullable: true),
                    rating = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK__Students__id__74AE54BC",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Declarative_Lessons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Declarative_Lessons_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Declarative_Lessons_pk", x => new { x.ID, x.paths_ID, x.courses_ID });
                    table.UniqueConstraint("AK_Declarative_Lessons_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Declarati__cours__5AEE82B9",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Declarati__paths__693CA210",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    strearms_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    end_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Streams_pk", x => new { x.ID, x.paths_ID, x.courses_ID });
                    table.UniqueConstraint("AK_Streams_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Streams__courses__571DF1D5",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Streams__paths_I__5629CD9C",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    stream_ID = table.Column<int>(type: "int", nullable: true),
                    Paths_ID = table.Column<int>(type: "int", nullable: true),
                    courses_ID = table.Column<int>(type: "int", nullable: true),
                    Lecturers_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Groups__courses___6754599E",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Groups__Lecturer__73BA3083",
                        column: x => x.Lecturers_ID,
                        principalTable: "Lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Groups__Paths_ID__74AE54BC",
                        column: x => x.Paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Groups__stream_I__656C112C",
                        column: x => x.stream_ID,
                        principalTable: "Streams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    message_content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    name = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_receiver_id = table.Column<int>(type: "int", nullable: true),
                    user_sender_id = table.Column<int>(type: "int", nullable: true),
                    group_receiver_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chats__0BBF6EE6DEFE4AFE", x => x.message_id);
                    table.ForeignKey(
                        name: "FK__Chats__group_rec__5DCAEF64",
                        column: x => x.group_receiver_id,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Chats__user_rece__32AB8735",
                        column: x => x.user_receiver_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Chats__user_send__339FAB6E",
                        column: x => x.user_sender_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    MeetingID = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    duration = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Lecturers_ID = table.Column<int>(type: "int", nullable: true),
                    Groups_ID = table.Column<int>(type: "int", nullable: true),
                    Streams_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Lessons_pk", x => new { x.ID, x.paths_ID, x.courses_ID, x.declarative_Lessons_ID });
                    table.UniqueConstraint("AK_Lessons_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Lessons__courses__6E01572D",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Lessons__declara__6D0D32F4",
                        column: x => x.declarative_Lessons_ID,
                        principalTable: "Declarative_Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Lessons__Groups___70DDC3D8",
                        column: x => x.Groups_ID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Lessons__Lecture__6FE99F9F",
                        column: x => x.Lecturers_ID,
                        principalTable: "Lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Lessons__paths_I__6EF57B66",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Lessons__Streams__71D1E811",
                        column: x => x.Streams_ID,
                        principalTable: "Streams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    lessons_ID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    dueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    assignments_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Assignments_pk", x => new { x.ID, x.paths_ID, x.courses_ID, x.declarative_Lessons_ID, x.lessons_ID });
                    table.UniqueConstraint("AK_Assignments_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Assignmen__cours__7E37BEF6",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Assignmen__decla__5AEE82B9",
                        column: x => x.declarative_Lessons_ID,
                        principalTable: "Declarative_Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Assignmen__lesso__00200768",
                        column: x => x.lessons_ID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Assignmen__paths__5CD6CB2B",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LearningMaterials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: true),
                    courses_ID = table.Column<int>(type: "int", nullable: true),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: true),
                    lessons_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterials", x => x.ID);
                    table.ForeignKey(
                        name: "FK__LearningM__cours__1CBC4616",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LearningM__decla__778AC167",
                        column: x => x.declarative_Lessons_ID,
                        principalTable: "Declarative_Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LearningM__lesso__1EA48E88",
                        column: x => x.lessons_ID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LearningM__paths__797309D9",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files_assignments",
                columns: table => new
                {
                    files_ID = table.Column<int>(type: "int", nullable: true),
                    assignments_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__files_ass__assig__6C190EBB",
                        column: x => x.assignments_ID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__files_ass__files__17F790F9",
                        column: x => x.files_ID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: false),
                    courses_ID = table.Column<int>(type: "int", nullable: false),
                    paths_ID = table.Column<int>(type: "int", nullable: false),
                    lessons_ID = table.Column<int>(type: "int", nullable: false),
                    assignments_ID = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    students_ID = table.Column<int>(type: "int", nullable: true),
                    mark = table.Column<int>(type: "int", nullable: false),
                    submissions_identity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Submissions_pk", x => new { x.ID, x.paths_ID, x.courses_ID, x.declarative_Lessons_ID, x.lessons_ID, x.assignments_ID });
                    table.UniqueConstraint("AK_Submissions_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Submissio__assig__0A9D95DB",
                        column: x => x.assignments_ID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Submissio__cours__04E4BC85",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Submissio__decla__0C85DE4D",
                        column: x => x.declarative_Lessons_ID,
                        principalTable: "Declarative_Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Submissio__lesso__06CD04F7",
                        column: x => x.lessons_ID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Submissio__paths__0E6E26BF",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Submissio__stude__0F624AF8",
                        column: x => x.students_ID,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files_learningMaterials",
                columns: table => new
                {
                    files_ID = table.Column<int>(type: "int", nullable: true),
                    learningMaterials_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__files_lea__files__208CD6FA",
                        column: x => x.files_ID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__files_lea__learn__6EF57B66",
                        column: x => x.learningMaterials_ID,
                        principalTable: "LearningMaterials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    assignments_ID = table.Column<int>(type: "int", nullable: true),
                    users_ID = table.Column<int>(type: "int", nullable: true),
                    submissions_ID = table.Column<int>(type: "int", nullable: true),
                    paths_ID = table.Column<int>(type: "int", nullable: true),
                    courses_ID = table.Column<int>(type: "int", nullable: true),
                    declarative_Lessons_ID = table.Column<int>(type: "int", nullable: true),
                    lessons_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Comments__assign__60A75C0F",
                        column: x => x.assignments_ID,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__course__0F624AF8",
                        column: x => x.courses_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__declar__628FA481",
                        column: x => x.declarative_Lessons_ID,
                        principalTable: "Declarative_Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__lesson__114A936A",
                        column: x => x.lessons_ID,
                        principalTable: "Lessons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__paths___6477ECF3",
                        column: x => x.paths_ID,
                        principalTable: "Paths",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__submis__656C112C",
                        column: x => x.submissions_ID,
                        principalTable: "Submissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comments__users___0C85DE4D",
                        column: x => x.users_ID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    submissions_id = table.Column<int>(type: "int", nullable: true),
                    assignments_id = table.Column<int>(type: "int", nullable: true),
                    events_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__assig__04E4BC85",
                        column: x => x.assignments_id,
                        principalTable: "Assignments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Notificat__event__2BFE89A6",
                        column: x => x.events_id,
                        principalTable: "Events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Notificat__submi__06CD04F7",
                        column: x => x.submissions_id,
                        principalTable: "Submissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notification_groups",
                columns: table => new
                {
                    groups_ID = table.Column<int>(type: "int", nullable: true),
                    notifications_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__notificat__group__01142BA1",
                        column: x => x.groups_ID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__notificat__notif__02084FDA",
                        column: x => x.notifications_ID,
                        principalTable: "Notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notification_user",
                columns: table => new
                {
                    users_ID = table.Column<int>(type: "int", nullable: true),
                    notifications_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__notificat__notif__02FC7413",
                        column: x => x.notifications_ID,
                        principalTable: "Notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__notificat__users__367C1819",
                        column: x => x.users_ID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_courses_ID",
                table: "Assignments",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_declarative_Lessons_ID",
                table: "Assignments",
                column: "declarative_Lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_lessons_ID",
                table: "Assignments",
                column: "lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_paths_ID",
                table: "Assignments",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Assignme__3214EC2672E9EF64",
                table: "Assignments",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_group_receiver_id",
                table: "Chats",
                column: "group_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_user_receiver_id",
                table: "Chats",
                column: "user_receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_user_sender_id",
                table: "Chats",
                column: "user_sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_assignments_ID",
                table: "Comments",
                column: "assignments_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_courses_ID",
                table: "Comments",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_declarative_Lessons_ID",
                table: "Comments",
                column: "declarative_Lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_lessons_ID",
                table: "Comments",
                column: "lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_paths_ID",
                table: "Comments",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_submissions_ID",
                table: "Comments",
                column: "submissions_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_users_ID",
                table: "Comments",
                column: "users_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_paths_ID",
                table: "Courses",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Courses__3214EC26ABD85FA4",
                table: "Courses",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Declarative_Lessons_courses_ID",
                table: "Declarative_Lessons",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Declarative_Lessons_paths_ID",
                table: "Declarative_Lessons",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Declarat__3214EC2646CDBBEA",
                table: "Declarative_Lessons",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_folder_parentID",
                table: "Files",
                column: "folder_parentID");

            migrationBuilder.CreateIndex(
                name: "IX_files_assignments_assignments_ID",
                table: "files_assignments",
                column: "assignments_ID");

            migrationBuilder.CreateIndex(
                name: "IX_files_assignments_files_ID",
                table: "files_assignments",
                column: "files_ID");

            migrationBuilder.CreateIndex(
                name: "IX_files_learningMaterials_files_ID",
                table: "files_learningMaterials",
                column: "files_ID");

            migrationBuilder.CreateIndex(
                name: "IX_files_learningMaterials_learningMaterials_ID",
                table: "files_learningMaterials",
                column: "learningMaterials_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_receiver_id",
                table: "Finances",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_sender_id",
                table: "Finances",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Graduations_paths_ID",
                table: "Graduations",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Graduati__3214EC26F16DDBC7",
                table: "Graduations",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_courses_ID",
                table: "Groups",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Lecturers_ID",
                table: "Groups",
                column: "Lecturers_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Paths_ID",
                table: "Groups",
                column: "Paths_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_stream_ID",
                table: "Groups",
                column: "stream_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_courses_ID",
                table: "LearningMaterials",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_declarative_Lessons_ID",
                table: "LearningMaterials",
                column: "declarative_Lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_lessons_ID",
                table: "LearningMaterials",
                column: "lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_paths_ID",
                table: "LearningMaterials",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_courses_ID",
                table: "Lessons",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_declarative_Lessons_ID",
                table: "Lessons",
                column: "declarative_Lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Groups_ID",
                table: "Lessons",
                column: "Groups_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Lecturers_ID",
                table: "Lessons",
                column: "Lecturers_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_paths_ID",
                table: "Lessons",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Streams_ID",
                table: "Lessons",
                column: "Streams_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Lessons__3214EC26438CC650",
                table: "Lessons",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notification_groups_groups_ID",
                table: "notification_groups",
                column: "groups_ID");

            migrationBuilder.CreateIndex(
                name: "IX_notification_groups_notifications_ID",
                table: "notification_groups",
                column: "notifications_ID");

            migrationBuilder.CreateIndex(
                name: "IX_notification_user_notifications_ID",
                table: "notification_user",
                column: "notifications_ID");

            migrationBuilder.CreateIndex(
                name: "IX_notification_user_users_ID",
                table: "notification_user",
                column: "users_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_assignments_id",
                table: "Notifications",
                column: "assignments_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_events_id",
                table: "Notifications",
                column: "events_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_submissions_id",
                table: "Notifications",
                column: "submissions_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Paths__72E12F1BB1F7F5E8",
                table: "Paths",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Streams_courses_ID",
                table: "Streams",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_paths_ID",
                table: "Streams",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Streams__3214EC26827AA00E",
                table: "Streams",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_assignments_ID",
                table: "Submissions",
                column: "assignments_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_courses_ID",
                table: "Submissions",
                column: "courses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_declarative_Lessons_ID",
                table: "Submissions",
                column: "declarative_Lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_lessons_ID",
                table: "Submissions",
                column: "lessons_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_paths_ID",
                table: "Submissions",
                column: "paths_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_students_ID",
                table: "Submissions",
                column: "students_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Submissi__3214EC26FC7F699B",
                table: "Submissions",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__7A2129048A1A65BF",
                table: "Users",
                column: "mail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "files_assignments");

            migrationBuilder.DropTable(
                name: "files_learningMaterials");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "Graduations");

            migrationBuilder.DropTable(
                name: "Group_ConsistsOf_Students");

            migrationBuilder.DropTable(
                name: "notification_groups");

            migrationBuilder.DropTable(
                name: "notification_user");

            migrationBuilder.DropTable(
                name: "Student_Participate_Lessons");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "LearningMaterials");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Declarative_Lessons");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Paths");
        }
    }
}
