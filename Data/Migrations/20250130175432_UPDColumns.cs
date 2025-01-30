using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UPDColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Columns_ToDoLists_ToDoListId",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Columns_ToDoListId",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "ToDoListId",
                table: "Columns");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDoLists",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "ColumnId",
                table: "ToDoLists",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Columns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ColumnId",
                table: "ToDoLists",
                column: "ColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Columns_ColumnId",
                table: "ToDoLists",
                column: "ColumnId",
                principalTable: "Columns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Columns_ColumnId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_ColumnId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Columns");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ToDoLists",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToDoListId",
                table: "Columns",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_ToDoListId",
                table: "Columns",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_ToDoLists_ToDoListId",
                table: "Columns",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id");
        }
    }
}
