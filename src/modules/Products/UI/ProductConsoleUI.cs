using MyInventory2026.src.modules.Products.Application.Interfaces;
using MyInventory2026.src.shared.ui;

namespace MyInventory2026.src.modules.Products.UI;

public sealed class ProductConsoleUI : IModuleUI
{
    private readonly IProductService _productService;

    public ProductConsoleUI(IProductService productService)
    {
        _productService = productService;
    }

    public string Key => "2";
    public string Title => "Product";

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== CRUD PRODUCT ===");
            Console.WriteLine("1. Crear product");
            Console.WriteLine("2. Listar products");
            Console.WriteLine("3. Buscar product por id");
            Console.WriteLine("4. Actualizar product");
            Console.WriteLine("5. Eliminar product");
            Console.WriteLine("0. Volver al menu principal");
            Console.Write("Selecciona una opción: ");

            var option = Console.ReadLine()?.Trim();
            Console.WriteLine();

            try
            {
                switch (option)
                {
                    case "1":
                        await CreateProductAsync(cancellationToken);
                        break;
                    case "2":
                        await ListProductsAsync(cancellationToken);
                        break;
                    case "3":
                        await GetProductByIdAsync(cancellationToken);
                        break;
                    case "4":
                        await UpdateProductAsync(cancellationToken);
                        break;
                    case "5":
                        await DeleteProductAsync(cancellationToken);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private async Task CreateProductAsync(CancellationToken cancellationToken)
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? string.Empty;

        var created = await _productService.CreateAsync(id, name, cancellationToken);
        Console.WriteLine($"Product creado. Id: {created.Id.Value}, Name: {created.Name.Value}");
    }

    private async Task ListProductsAsync(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);

        if (products.Count == 0)
        {
            Console.WriteLine("No hay products registrados.");
            return;
        }

        foreach (var product in products)
        {
            Console.WriteLine($"- Id: {product.Id.Value} | Name: {product.Name.Value}");
        }
    }

    private async Task GetProductByIdAsync(CancellationToken cancellationToken)
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var product = await _productService.GetByIdAsync(id, cancellationToken);

        if (product is null)
        {
            Console.WriteLine("Product no encontrado.");
            return;
        }

        Console.WriteLine($"Id: {product.Id.Value}");
        Console.WriteLine($"Name: {product.Name.Value}");
    }

    private async Task UpdateProductAsync(CancellationToken cancellationToken)
    {
        Console.Write("Id del product a actualizar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }
        Console.Write("Nuevo name: ");
        var name = Console.ReadLine() ?? string.Empty;

        var updated = await _productService.UpdateAsync(id, name, cancellationToken);
        Console.WriteLine($"Product actualizado. Id: {updated.Id.Value}, Name: {updated.Name.Value}");
    }

    private async Task DeleteProductAsync(CancellationToken cancellationToken)
    {
        Console.Write("Id del product a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var deleted = await _productService.DeleteAsync(id, cancellationToken);
        Console.WriteLine(deleted ? "Product eliminado." : "Product no encontrado.");
    }
}