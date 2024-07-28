using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS.Entity.Migrations
{
    public partial class AddPushNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                schema: "authentication",
                table: "UserLoginLog",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "authentication",
                table: "UserLoginLog",
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

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                schema: "sys",
                table: "Screen",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Model",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Model",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "cms",
                table: "log_history",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "cms",
                table: "log_history",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Issue",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Issue",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

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
                name: "modified_date",
                schema: "csms",
                table: "Comment",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Comment",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
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

            migrationBuilder.CreateTable(
                name: "PushNotifications",
                schema: "csms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Body = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PushNotifications_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PushNotifications_AppUserId",
                schema: "csms",
                table: "PushNotifications",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screen_Screen_parent_id",
                schema: "sys",
                table: "Screen",
                column: "parent_id",
                principalSchema: "sys",
                principalTable: "Screen",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "PushNotifications",
                schema: "csms");

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

            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                schema: "sys",
                table: "screen",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Model",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Model",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "cms",
                table: "log_history",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "cms",
                table: "log_history",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "modified_date",
                schema: "csms",
                table: "Issue",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Issue",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

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
                name: "modified_date",
                schema: "csms",
                table: "Comment",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                schema: "csms",
                table: "Comment",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

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
    }
}
