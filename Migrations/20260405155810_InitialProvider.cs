using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyInventory2026.Migrations
{
    /// <inheritdoc />
    public partial class InitialProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS `providers` (
                    `id` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
                    `name` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
                    CONSTRAINT `PK_providers` PRIMARY KEY (`id`)
                ) CHARACTER SET=utf8mb4;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE IF EXISTS `providers`;");
        }
    }
}
