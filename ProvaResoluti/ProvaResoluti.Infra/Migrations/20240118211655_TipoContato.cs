using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaResoluti.Infra.Migrations
{
    public partial class TipoContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoContato",
                schema: "Resoluti",
                table: "Contatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoContato",
                schema: "Resoluti",
                table: "Contatos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
