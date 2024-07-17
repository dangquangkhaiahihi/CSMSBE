using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSMS.Entity.Migrations
{
    public partial class CreateIssueCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screen_Screen_parent_id",
                schema: "sys",
                table: "Screen");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityMatrix_Action_action_id",
                schema: "sys",
                table: "SecurityMatrix");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityMatrix_AspNetRoles_role_id",
                schema: "sys",
                table: "SecurityMatrix");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityMatrix_Screen_screen_id",
                schema: "sys",
                table: "SecurityMatrix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screen",
                schema: "sys",
                table: "Screen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Action",
                schema: "sys",
                table: "Action");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityMatrix",
                schema: "sys",
                table: "SecurityMatrix");

            migrationBuilder.EnsureSchema(
                name: "cms");

            migrationBuilder.EnsureSchema(
                name: "authentication");

            migrationBuilder.RenameTable(
                name: "Screen",
                schema: "sys",
                newName: "screen",
                newSchema: "sys");

            migrationBuilder.RenameTable(
                name: "Action",
                schema: "sys",
                newName: "action",
                newSchema: "sys");

            migrationBuilder.RenameTable(
                name: "UserLoginLog",
                schema: "sys",
                newName: "UserLoginLog",
                newSchema: "authentication");

            migrationBuilder.RenameTable(
                name: "SecurityMatrix",
                schema: "sys",
                newName: "security_matrix",
                newSchema: "sys");

            migrationBuilder.RenameIndex(
                name: "IX_Screen_parent_id",
                schema: "sys",
                table: "screen",
                newName: "IX_screen_parent_id");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityMatrix_screen_id",
                schema: "sys",
                table: "security_matrix",
                newName: "IX_security_matrix_screen_id");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityMatrix_role_id",
                schema: "sys",
                table: "security_matrix",
                newName: "IX_security_matrix_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_SecurityMatrix_action_id",
                schema: "sys",
                table: "security_matrix",
                newName: "IX_security_matrix_action_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "UserProject",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "UserProject",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "TypeProject",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "TypeProject",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "Province",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "Province",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Project",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id",
                schema: "csms",
                table: "Project",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "District",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "District",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "Commune",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "Commune",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredTime",
                table: "AspNetUserTokens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AspNetRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AspNetRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "AspNetRefreshTokens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "AspNetRefreshTokens",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "AspNetRefreshTokens",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "authentication",
                table: "UserLoginLog",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "authentication",
                table: "UserLoginLog",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_screen",
                schema: "sys",
                table: "screen",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_action",
                schema: "sys",
                table: "action",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_security_matrix",
                schema: "sys",
                table: "security_matrix",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Issue",
                schema: "csms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<string>(type: "text", nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "csms",
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "log_history",
                schema: "cms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    action = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<string>(type: "text", nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "csms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IssueId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<string>(type: "text", nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_delete = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Issue_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "csms",
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IssueId",
                schema: "csms",
                table: "Comment",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                schema: "csms",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_ProjectId",
                schema: "csms",
                table: "Issue",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_UserId",
                schema: "csms",
                table: "Issue",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_screen_screen_parent_id",
                schema: "sys",
                table: "screen",
                column: "parent_id",
                principalSchema: "sys",
                principalTable: "screen",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_security_matrix_action_action_id",
                schema: "sys",
                table: "security_matrix",
                column: "action_id",
                principalSchema: "sys",
                principalTable: "action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_security_matrix_AspNetRoles_role_id",
                schema: "sys",
                table: "security_matrix",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_security_matrix_screen_screen_id",
                schema: "sys",
                table: "security_matrix",
                column: "screen_id",
                principalSchema: "sys",
                principalTable: "screen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_screen_screen_parent_id",
                schema: "sys",
                table: "screen");

            migrationBuilder.DropForeignKey(
                name: "FK_security_matrix_action_action_id",
                schema: "sys",
                table: "security_matrix");

            migrationBuilder.DropForeignKey(
                name: "FK_security_matrix_AspNetRoles_role_id",
                schema: "sys",
                table: "security_matrix");

            migrationBuilder.DropForeignKey(
                name: "FK_security_matrix_screen_screen_id",
                schema: "sys",
                table: "security_matrix");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "csms");

            migrationBuilder.DropTable(
                name: "log_history",
                schema: "cms");

            migrationBuilder.DropTable(
                name: "Issue",
                schema: "csms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_screen",
                schema: "sys",
                table: "screen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_action",
                schema: "sys",
                table: "action");

            migrationBuilder.DropPrimaryKey(
                name: "PK_security_matrix",
                schema: "sys",
                table: "security_matrix");

            migrationBuilder.RenameTable(
                name: "screen",
                schema: "sys",
                newName: "Screen",
                newSchema: "sys");

            migrationBuilder.RenameTable(
                name: "action",
                schema: "sys",
                newName: "Action",
                newSchema: "sys");

            migrationBuilder.RenameTable(
                name: "UserLoginLog",
                schema: "authentication",
                newName: "UserLoginLog",
                newSchema: "sys");

            migrationBuilder.RenameTable(
                name: "security_matrix",
                schema: "sys",
                newName: "SecurityMatrix",
                newSchema: "sys");

            migrationBuilder.RenameIndex(
                name: "IX_screen_parent_id",
                schema: "sys",
                table: "Screen",
                newName: "IX_Screen_parent_id");

            migrationBuilder.RenameIndex(
                name: "IX_security_matrix_screen_id",
                schema: "sys",
                table: "SecurityMatrix",
                newName: "IX_SecurityMatrix_screen_id");

            migrationBuilder.RenameIndex(
                name: "IX_security_matrix_role_id",
                schema: "sys",
                table: "SecurityMatrix",
                newName: "IX_SecurityMatrix_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_security_matrix_action_id",
                schema: "sys",
                table: "SecurityMatrix",
                newName: "IX_SecurityMatrix_action_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "UserProject",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "UserProject",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "TypeProject",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "TypeProject",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "SomeTable",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "Province",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "Province",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Project",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Project",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                schema: "csms",
                table: "Project",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "District",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "District",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "Commune",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "Commune",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiredTime",
                table: "AspNetUserTokens",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetRoles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                table: "AspNetRefreshTokens",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "AspNetRefreshTokens",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expires",
                table: "AspNetRefreshTokens",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "sys",
                table: "UserLoginLog",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "sys",
                table: "UserLoginLog",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screen",
                schema: "sys",
                table: "Screen",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Action",
                schema: "sys",
                table: "Action",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityMatrix",
                schema: "sys",
                table: "SecurityMatrix",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Screen_Screen_parent_id",
                schema: "sys",
                table: "Screen",
                column: "parent_id",
                principalSchema: "sys",
                principalTable: "Screen",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityMatrix_Action_action_id",
                schema: "sys",
                table: "SecurityMatrix",
                column: "action_id",
                principalSchema: "sys",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityMatrix_AspNetRoles_role_id",
                schema: "sys",
                table: "SecurityMatrix",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityMatrix_Screen_screen_id",
                schema: "sys",
                table: "SecurityMatrix",
                column: "screen_id",
                principalSchema: "sys",
                principalTable: "Screen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
