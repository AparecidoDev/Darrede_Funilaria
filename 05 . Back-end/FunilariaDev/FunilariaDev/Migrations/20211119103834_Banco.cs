using Microsoft.EntityFrameworkCore.Migrations;

namespace FunilariaDev.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    IdBrand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBrand = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Problem = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<long>(type: "BIGINT", maxLength: 11, nullable: false),
                    ImagePlate = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Plate = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    TypeUser = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "templates",
                columns: table => new
                {
                    IdModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    NameModel = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_templates", x => x.IdModel);
                    table.ForeignKey(
                        name: "FK_templates_Brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brands",
                        principalColumn: "IdBrand",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Color = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Brand = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                    table.ForeignKey(
                        name: "FK_Cars_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    IdBudget = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdModel = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    TotalValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.IdBudget);
                    table.ForeignKey(
                        name: "FK_Budgets_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budgets_templates_IdModel",
                        column: x => x.IdModel,
                        principalTable: "templates",
                        principalColumn: "IdModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_NameBrand",
                table: "Brands",
                column: "NameBrand",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_IdModel",
                table: "Budgets",
                column: "IdModel");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_IdService",
                table: "Budgets",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdUser",
                table: "Cars",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Plate",
                table: "Cars",
                column: "Plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Problem",
                table: "Services",
                column: "Problem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_templates_IdBrand",
                table: "templates",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_templates_NameModel",
                table: "templates",
                column: "NameModel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                table: "Users",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "templates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
