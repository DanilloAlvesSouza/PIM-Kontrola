using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontrola.Migrations
{
    /// <inheritdoc />
    public partial class popularTabelasEstaticas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Gravidades(Descricao)" +
                "VALUES('Sem gravidade')");
            migrationBuilder.Sql("INSERT INTO Gravidades(Descricao)" +
                "VALUES('Pouco grave')");
            migrationBuilder.Sql("INSERT INTO Gravidades(Descricao)" +
                "VALUES('Grave')");
            migrationBuilder.Sql("INSERT INTO Gravidades(Descricao)" +
                "VALUES('Muito Grave')");
            migrationBuilder.Sql("INSERT INTO Gravidades(Descricao)" +
                "VALUES('Extremamente grave')");
            migrationBuilder.Sql("INSERT INTO Urgencias(Descricao)" +
                "VALUES('Pode esperar')");
            migrationBuilder.Sql("INSERT INTO Urgencias(Descricao)" +
                "VALUES('Pouco urgente')");
            migrationBuilder.Sql("INSERT INTO Urgencias(Descricao)" +
                "VALUES('Urgente, merece atenção no curto prazo')");
            migrationBuilder.Sql("INSERT INTO Urgencias(Descricao)" +
                "VALUES('Muito urgente')");
            migrationBuilder.Sql("INSERT INTO Urgencias(Descricao)" +
                "VALUES('Necessidade de ação imediata')");
            migrationBuilder.Sql("INSERT INTO Tendencias(Descricao)" +
                "VALUES('Não irá mudar')");
            migrationBuilder.Sql("INSERT INTO Tendencias(Descricao)" +
                "VALUES('Irá piorar a longo prazo')");
            migrationBuilder.Sql("INSERT INTO Tendencias(Descricao)" +
                "VALUES('Irá piorar a médio prazo')");
            migrationBuilder.Sql("INSERT INTO Tendencias(Descricao)" +
                "VALUES('Irá piorar a curto prazo')");
            migrationBuilder.Sql("INSERT INTO Tendencias(Descricao)" +
                "VALUES('Irá piorar rapidamente')");
            migrationBuilder.Sql("INSERT INTO Status(Descricao) VALUES('Pendente')");
            migrationBuilder.Sql("INSERT INTO Status(Descricao) VALUES('Agendado')");
            migrationBuilder.Sql("INSERT INTO Status(Descricao) VALUES('Em Andamento')");
            migrationBuilder.Sql("INSERT INTO Status(Descricao) VALUES('Concluido')");
            migrationBuilder.Sql("INSERT INTO Modalidades(Descricao) Values('Preventiva')");
            migrationBuilder.Sql("INSERT INTO Modalidades(Descricao) Values('Corretiva')");
            migrationBuilder.Sql("INSERT INTO Modalidades(Descricao) Values('Preditiva')");
            migrationBuilder.Sql("INSERT INTO Modalidades(Descricao) Values('Verificação')");
            migrationBuilder.Sql("INSERT INTO Modalidades(Descricao) Values('Vistoria')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Gravidades");
            migrationBuilder.Sql("DELETE FROM Urgencias");
            migrationBuilder.Sql("DELETE FROM Tendencias");
            migrationBuilder.Sql("DELETE FROM Status");
            migrationBuilder.Sql("DELETE FROM Modalidades");
        }
    }
}
