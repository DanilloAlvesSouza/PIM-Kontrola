using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontrola.Migrations
{
    public partial class AjusteTablesEquipamentoECliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TensaoEntrada",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TensaoSaida",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Chamados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_ClienteId",
                table: "Chamados",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Cliente_ClienteId",
                table: "Chamados",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Cliente_ClienteId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_ClienteId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "TensaoEntrada",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "TensaoSaida",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Chamados");
        }
    }
}
