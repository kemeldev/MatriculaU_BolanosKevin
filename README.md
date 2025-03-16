# Proyecto: Sistema de Gestión de Matrícula Universitaria

## Descripción

Este proyecto es una aplicación web para la gestión de matrículas universitarias, desarrollada con la arquitectura Modelo-Vista-Controlador (MVC). Se implementa utilizando C# en Visual Studio 2022, junto con SQL Server para la gestión de bases de datos mediante Entity Framework (Code First).

## Tecnologías Utilizadas

Lenguaje de Programación: C#

Framework: ASP.NET Core con Razor Pages

Base de Datos: SQL Server

ORM: Entity Framework (Code First)

Frontend: HTML, CSS, Bootstrap

Gestión de Autenticación: ASP.NET Identity

## Funcionalidades Principales

Gestión de Estudiantes, Carreras, Cursos y Docentes.

CRUD completo para la administración de datos.

Autenticación y autorización con roles mediante ASP.NET Identity.

Migraciones para la estructuración de la base de datos.

Interfaz responsiva con Bootstrap.

## Estructura del Proyecto

 Proyecto
	   Controllers          # Controladores para la gestión de datos
	   Views                # Vistas en Razor Pages
	   wwwroot              # Archivos estáticos (CSS, JS, imágenes)
	   Models               # Modelos de datos
	   Data                 # Contexto y migraciones de base de datos
	   Migrations           # Migraciones de Entity Framework
	   Services             # Servicios de aplicación
	   Identity             # Implementación de autenticación y roles
	   appsettings.json     # Configuración de la aplicación
	   Program.cs           # Configuración del servidor
	   Startup.cs           # Configuración de middleware y servicios

## Instalación y Configuración

Clonar el repositorio:

git clone https://github.com/kemeldev/MatriculaU_BolanosKevin

Abrir el proyecto en Visual Studio 2022.

Configurar la cadena de conexión en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;Trusted_Connection=True;"
}

Ejecutar las migraciones para crear la base de datos:

dotnet ef database update

Ejecutar la aplicación:

dotnet run

## Uso

Accede a la aplicación desde el navegador en http://localhost:5000.

Registra un usuario y accede con sus credenciales.

Gestiona carreras, estudiantes y profesores desde el panel de administración.

## Contribución

Las contribuciones son bienvenidas. Para colaborar:

Realiza un fork del repositorio.

Crea una nueva rama (feature/nueva-funcionalidad).

Realiza tus cambios y haz un commit.

Envía un pull request.

## Licencia

Este proyecto está bajo la licencia MIT. Para más detalles, revisa el archivo LICENSE.

Proyecto desarrollado para la gestión eficiente de matrículas universitarias.