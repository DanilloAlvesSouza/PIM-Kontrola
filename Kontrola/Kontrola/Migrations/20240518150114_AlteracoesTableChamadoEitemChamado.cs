using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontrola.Migrations
{
    /// <inheritdoc />
    public partial class AlteracoesTableChamadoEitemChamado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItemChamados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItemChamados");
        }
    }
}
