# Entity Framework Core - Migraciones y Actualización de la Base de Datos

Este documento explica los pasos necesarios para crear una migración con **Entity Framework Core** y aplicarla a la base de datos.

---

## Requisitos previos

Antes de proceder, asegúrate de cumplir con los siguientes requisitos:

1. **Paquetes necesarios** instalados en tu proyecto que contiene el `DbContext`:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   ```

2. **Archivo de configuración** (`appsettings.json`) con una cadena de conexión válida:
   ```json
   {
     "ConnectionStrings": {
       "DevConnection": "Server=localhost;Database=SistemaMedico;User Id=sa;Password=your_password;TrustServerCertificate=True;"
     }
   }
   ```

3. **DbContext** configurado en el proyecto (ejemplo en `Startup.cs` o `Program.cs`):
   ```csharp
   services.AddDbContext<SistemaMedicoContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
   ```

---

## Crear una migración

1. **Ubicación del `DbContext`:**
   Asegúrate de que tu clase `DbContext` esté en el proyecto correcto. Por ejemplo, si está en `SistemaMedico.Infrastructure`.

2. **Generar la migración:**
   Ejecuta el siguiente comando desde la raíz de tu solución para crear una migración:
   ```bash
   dotnet ef migrations add InitialCreate --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
   ```

   - **`--project`**: Especifica el proyecto que contiene tu `DbContext` (en este caso, `SistemaMedico.Infrastructure`).
   - **`--startup-project`**: Especifica el proyecto de inicio (en este caso, `SistemaMedico.Api`).
   - **`InitialCreate`**: Es el nombre de la migración; puedes usar cualquier nombre que describa los cambios realizados en el modelo.

3. **Resultado:**
   Una nueva carpeta llamada `Migrations` será creada en tu proyecto (`SistemaMedico.Infrastructure`) con archivos que describen los cambios en el esquema.

---

## Actualizar la base de datos

1. **Aplicar la migración a la base de datos:**
   Ejecuta el siguiente comando:
   ```bash
   dotnet ef database update --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
   ```

   Esto actualizará la base de datos según las migraciones generadas.

2. **Verificar cambios:**
   Abre tu herramienta de administración de base de datos (SQL Server Management Studio o Azure Data Studio) para confirmar que:
   - La base de datos `SistemaMedico` fue creada (si no existía).
   - Las tablas definidas en el modelo están presentes.
   - La tabla `__EFMigrationsHistory` contiene un registro de las migraciones aplicadas.

---

## Flujo completo de migraciones

1. **Modificar el modelo**: Si realizas cambios en tu modelo, repite el proceso de crear una migración y aplicar los cambios:
   - Crear una nueva migración:
     ```bash
     dotnet ef migrations add NombreDeLaNuevaMigracion --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
     ```
   - Aplicar la migración:
     ```bash
     dotnet ef database update --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
     ```

---

## Solución a problemas comunes

1. **Error: `No executable found matching command "dotnet-ef"`:**
   Asegúrate de tener instalado el CLI de Entity Framework Core globalmente:
   ```bash
   dotnet tool install --global dotnet-ef
   ```

2. **Error: `A connection was successfully established, but then an error occurred during the login process`:**
   - Verifica que la cadena de conexión sea válida.
   - Agrega `TrustServerCertificate=True` si es necesario.

3. **Error: `Unable to create an object of type 'YourDbContext'`:**
   - Asegúrate de que el proyecto de inicio esté configurado correctamente.
   - Verifica que exista una implementación de `IDesignTimeDbContextFactory` si usas configuraciones avanzadas.

---

## Ejemplo de comandos rápidos

### Crear una migración:
```bash
dotnet ef migrations add NombreDeLaMigracion --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
```

### Aplicar las migraciones a la base de datos:
```bash
dotnet ef database update --project SistemaMedico.Infrastructure --startup-project SistemaMedico.Api
```
