# Sistema de Ventas (WIP)
![Estado](https://img.shields.io/badge/Estado-En%20Desarrollo-yellow) ![.NET](https://img.shields.io/badge/.NET-8.0-purple)
## 📌 Descripción General
Este es un proyecto de **Sistema de Ventas** desarrollado bajo la arquitectura **ASP.NET Core MVC**. Actualmente, el desarrollo se centra en la capa de mantenimiento y gestión de entidades maestras, contando con el módulo de **Clientes** totalmente operativo.
El objetivo del proyecto es completar el flujo de ventas, incluyendo la gestión de Artículos, Vendedores y el registro de Transacciones.
## 🚀 Funcionalidades Implementadas
### ✅ Gestión de Clientes (Módulo Actual)
El módulo de clientes implementa un flujo **CRUD** completo utilizando **ADO.NET** puro para un rendimiento óptimo:
- **Listado Paginado**: Navegación eficiente entre grandes volúmenes de registros.
- **Búsqueda y Filtrado**: Capacidad de buscar clientes por:
  - Código
  - Correo Electrónico
  - Distrito (Listado Dinámico)
- **Registro y Edición**: Formularios con validaciones de datos (`Data Annotations`) y protección `Anti-Forgery Token`.
- **Eliminación Lógica**: Implementación de deshabilitación de registros en lugar de borrado físico.
## 🛠 Stack Tecnológico
- **Framework Principal**: ASP.NET Core 8 MVC
- **Lenguaje**: C#
- **Base de Datos**: SQL Server
- **Acceso a Datos**: ADO.NET (`Microsoft.Data.SqlClient`)
  - Uso extensivo de **Stored Procedures** para lógica de base de datos.
- **Patrones de Diseño**:
  - **DAO** (Data Access Object) para encapsular el acceso a datos.
  - **DTO** (Data Transfer Object) para el transporte de datos entre capas.
- **Frontend**: Razor Views (.cshtml), Bootstrap.
## 📂 Estructura del Proyecto
El proyecto sigue una estructura limpia y separada por responsabilidades:
- `Controllers`: Controladores MVC (ej. `ClienteController`).
- `Dao`: Lógica de acceso a datos y conexión con SPs.
- `Models`: Entidades del dominio.
- `Dto`: Objetos de transferencia para Vistas y SPs.
- `Views`: Interfaz de usuario con Razor.
## ⚙️ Configuración y Ejecución
### Prerrequisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- SQL Server
### Instalación
1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/GerardGO/Proyecto_NetCore_MVC_SqlClient.git
2. **Configurar Base de Datos**:
- Asegúrate de tener creada la base de datos y los Procedimientos Almacenados requeridos (ej. SP_LISTAR_CLIENTES, SP_CREATE_CLIENTE, etc.).
- Configura la cadena de conexión en appsettings.json:
  ```bash
  "ConnectionStrings": {
  "cn1": "Data Source=LOCALHOST;Initial Catalog=TU_BD;Integrated Security=true;TrustServerCertificate=True"
  }
   
