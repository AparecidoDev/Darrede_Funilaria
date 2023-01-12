using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Funilaria.Infra.Data.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Imagem = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlacaCarro = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Cor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Ano = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Municipio = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Marca = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeloVeiculo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdMarca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaVeiculo = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    ModeloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marcas_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Marcas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorTotal = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    IdServico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdCarro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Problema = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ValorProblema = table.Column<double>(type: "float", maxLength: 15, nullable: false),
                    OrcamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_Marca",
                table: "Carros",
                column: "Marca",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_UsuarioId",
                table: "Carros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_ModeloId",
                table: "Marcas",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_UsuarioId",
                table: "Marcas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_UsuarioId",
                table: "Modelos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_CarroId",
                table: "Orcamentos",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ServicoId",
                table: "Orcamentos",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_UsuarioId",
                table: "Orcamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_UsuarioId",
                table: "Servicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Servicos_ServicoId",
                table: "Orcamentos",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_Usuarios_UsuarioId",
                table: "Carros");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Usuarios_UsuarioId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Usuarios_UsuarioId",
                table: "Servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Carros_CarroId",
                table: "Orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Servicos_ServicoId",
                table: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Orcamentos");
        }
    }
}
