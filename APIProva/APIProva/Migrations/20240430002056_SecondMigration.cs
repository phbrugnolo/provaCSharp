using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProva.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Folhas",
                newName: "FolhaId");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "FolhaId",
                table: "Folhas",
                newName: "FuncionarioId");
        }
    }
}
