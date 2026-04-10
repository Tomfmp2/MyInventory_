using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MyInventory2026.src.shared.context;

#nullable disable

namespace MyInventory2026.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260409190000_AddProductsTable")]
    public partial class AddProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS `products` (
                    `id` int NOT NULL,
                    `code_inv` varchar(100) CHARACTER SET utf8mb4 NULL,
                    `name_product` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
                    `stok` int NOT NULL,
                    `stok_min` int NOT NULL,
                    `stok_max` int NOT NULL,
                    CONSTRAINT `PK_products` PRIMARY KEY (`id`)
                ) CHARACTER SET=utf8mb4;
                """);

            migrationBuilder.Sql("""
                CREATE TABLE IF NOT EXISTS `provider_products` (
                    `provider_id` varchar(64) CHARACTER SET utf8mb4 NOT NULL,
                    `product_id` int NOT NULL,
                    CONSTRAINT `PK_provider_products` PRIMARY KEY (`provider_id`, `product_id`),
                    CONSTRAINT `FK_provider_products_providers_provider_id` FOREIGN KEY (`provider_id`) REFERENCES `providers` (`id`) ON DELETE CASCADE,
                    CONSTRAINT `FK_provider_products_products_product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE CASCADE
                ) CHARACTER SET=utf8mb4;
                """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE IF EXISTS `provider_products`;");
            migrationBuilder.Sql("DROP TABLE IF EXISTS `products`;");
        }
    }
}
