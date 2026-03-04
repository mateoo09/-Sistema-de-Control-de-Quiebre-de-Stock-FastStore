FastStore - Sistema de Gestión de Inventario

Este proyecto es una aplicación para gestion de inventario y órdenes de reposición.
Permite visualizar productos, identificar stock bajo y crear órdenes de reposición que actualizan el inventario.

El sistema está compuesto por:

Backend: ASP.NET Core Web API (.NET)
Frontend: Angular
Base de datos: SQL Server Express

Tecnologías utilizadas

BACKEND:
ASP.NET Core Web API
Entity Framework Core
SQL Server Express

FRONTEND:
Angular
Bootstrap

-----PASOS PARA EJECUTAR PROYECTO-------

Antes de ejecutar el proyecto se debe tener  instalado:

.NET SDK
Node.js
Angular CLI
SQL Server Express
SQL Server Management Studio (opcional)

Estructura del proyecto

El repositorio contiene dos carpetas principales:

FastStore.API  --> Backend (.NET Web API)
FastStore-Frontend --> Frontend (Angular)

Configuración de la base de datos:

El proyecto utiliza SQL Server Express. version (2025)

La cadena de conexión utilizada es:

Server=localhost\SQLEXPRESS01;Database=FastStoreDb;Trusted_Connection=True;TrustServerCertificate=True;

Cuando se ejecuta el backend por primera vez, Entity Framework crea automáticamente la base de datos mediante migraciones.

----Ejecutar el Backend-------

Abrir la carpeta del backend:

FastStore.API
Ejecutar el proyecto desde Visual Studio o desde terminal:

dotnet run --launch-profile https

La API quedará disponible en:
https://localhost:7265

Endpoints principales: a revisar

GET    /api/inventory

GET    /api/inventory/low-stock

POST   /api/orders


-----Ejecutar el Frontend-----

Abrir la carpeta:
FastStore-Frontend

Instalar dependencias:
npm install
Ejecutar Angular:
ng serve

Abrir en el navegador:

http://localhost:4200
Funcionalidades del sistema

La aplicación permite:

*Visualizar todos los productos del inventario
*Identificar productos con stock bajo
*Crear órdenes de reposición
*Actualizar el stock automáticamente después de crear una orden

Flujo del sistema:
Inventario --> detectar stock bajo --> crear orden --> actualizar stock

Autor: mateo osorno chavarria
