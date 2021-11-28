using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace desafioBackend.Migrations
{
    public partial class AddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<string>(nullable: false, maxLength: 15),
                    Logradouro = table.Column<string>(nullable: true, maxLength: 100),
                    Complemento = table.Column<string>(nullable: true, maxLength: 100),
                    Bairro = table.Column<string>(nullable: true, maxLength: 100),
                    Localidade = table.Column<string>(nullable: false, maxLength: 100),
                    UF = table.Column<string>(nullable: false, maxLength: 2),
                    IBGE = table.Column<int>(nullable: true, maxLength: 30),
                    Gia = table.Column<string>(nullable: true, maxLength: 30),
                    DDD = table.Column<int>(nullable: false, maxLength: 2),
                    Siafi = table.Column<int>(nullable: false, maxLength: 30)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.UniqueConstraint("UNIQUE_Address_Cep", x => x.Cep);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
