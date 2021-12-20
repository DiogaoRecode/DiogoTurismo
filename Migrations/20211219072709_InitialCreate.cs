using Microsoft.EntityFrameworkCore.Migrations;

namespace DiogoTurismo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id_cadastro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id_cadastro);
                });

            migrationBuilder.CreateTable(
                name: "Destino",
                columns: table => new
                {
                    Id_destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade_destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade_origem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destino", x => x.Id_destino);
                });

            migrationBuilder.CreateTable(
                name: "Passagens",
                columns: table => new
                {
                    Id_passagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_passaporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_saida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_chegada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario_saida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario_chegada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CadastroId_cadastro = table.Column<int>(type: "int", nullable: false),
                    DestinoId_destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens", x => x.Id_passagem);
                    table.ForeignKey(
                        name: "FK_Passagens_Cadastro_CadastroId_cadastro",
                        column: x => x.CadastroId_cadastro,
                        principalTable: "Cadastro",
                        principalColumn: "Id_cadastro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passagens_Destino_DestinoId_destino",
                        column: x => x.DestinoId_destino,
                        principalTable: "Destino",
                        principalColumn: "Id_destino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_CadastroId_cadastro",
                table: "Passagens",
                column: "CadastroId_cadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_DestinoId_destino",
                table: "Passagens",
                column: "DestinoId_destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagens");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Destino");
        }
    }
}
