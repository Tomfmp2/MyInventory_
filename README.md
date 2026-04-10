# MyInventory2026

> Inventario de proveedores y productos con EF Core y MySQL.

---

## 📌 Descripción

`MyInventory2026` es una aplicación de consola .NET 10 que gestiona:

- `providers`
- `products`
- `provider_products` (relación muchos a muchos)

La aplicación usa Entity Framework Core y `Pomelo.EntityFrameworkCore.MySql` para conectarse a una base de datos MySQL, aplicar migraciones y mantener la estructura de tablas.

---

## 🧱 Arquitectura del proyecto

El proyecto sigue una estructura modular:

- `src/modules/provider` — lógica de proveedor
- `src/modules/Products` — lógica de producto
- `src/shared/context` — `AppDbContext`, migraciones y `UnitOfWork`
- `src/shared/helpers` — fábrica de contexto y configuración de MySQL
- `src/shared/ui` — interfaz de usuario de consola modular

---

## 🚀 Requisitos

- .NET 10 SDK
- MySQL o MariaDB compatible
- Editor de texto o IDE (.NET compatible)

---

## ⚙️ Configuración

1. Copia o abre el archivo `appsettings.json`.
2. Ajusta la cadena de conexión de MySQL según tu entorno:

```json
{
  "ConnectionStrings": {
    "MySqlDB": "server=localhost;port=3307;database=inventory_db;user=root;password=1182007;SslMode=None;"
  }
}
```

3. Si tu MySQL corre en otro puerto, base o usuario, cámbialo aquí.

---

## ▶️ Ejecución

Desde la carpeta del proyecto, ejecuta:

```bash
dotnet restore
```

```bash
dotnet build
```

```bash
dotnet run
```

> El programa ejecuta `context.Database.Migrate()` al iniciar, así que creará las tablas necesarias automáticamente si la conexión está bien configurada.

---

## 🗂️ Comandos útiles

### Instalar `dotnet ef` (opcional)

```bash
dotnet tool install --global dotnet-ef
```

### Aplicar migraciones manualmente

```bash
dotnet ef database update
```

> Si no necesitas migraciones manuales, con `dotnet run` suele ser suficiente.

---

## 🎯 ¿Qué hace la app?

Al iniciar, muestra un menú de consola con dos módulos:

- Provider
- Product

Puedes crear, listar, buscar, actualizar y eliminar registros.

---

## ✅ Puntos clave

- El proyecto se ejecuta sobre `net10.0`
- Usa `Pomelo.EntityFrameworkCore.MySql` para MySQL
- Usa `Microsoft.EntityFrameworkCore.Design` para migraciones
- `appsettings.json` se copia al directorio de salida

---

## 💡 Notas importantes

- Asegúrate de que el servidor MySQL esté disponible antes de ejecutar.
- En Windows, si recibes errores de acceso al `.exe`, cierra cualquier instancia previa de la aplicación antes de compilar o ejecutar de nuevo.

---

## ✉️ Autor

**Tomás Felipe Medina Prada**  
📧 tom.pradamd@gmail.com

---

¡Listo! Ahora cualquier persona podrá entender el proyecto y ponerlo en marcha en su máquina con facilidad.
