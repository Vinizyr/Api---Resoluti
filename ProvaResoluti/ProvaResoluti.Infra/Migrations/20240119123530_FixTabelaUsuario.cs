using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaResoluti.Infra.Migrations
{
    public partial class FixTabelaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaFisicaId",
                schema: "Resoluti",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaId",
                schema: "Resoluti",
                table: "Usuario",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
