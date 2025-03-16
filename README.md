# Proyecto: Sistema de Gesti�n de Matr�cula Universitaria

## Descripci�n

Este proyecto es una aplicaci�n web para la gesti�n de matr�culas universitarias, desarrollada con la arquitectura Modelo-Vista-Controlador (MVC). Se implementa utilizando C# en Visual Studio 2022, junto con SQL Server para la gesti�n de bases de datos mediante Entity Framework (Code First).

## Tecnolog�as Utilizadas

Lenguaje de Programaci�n: C#

Framework: ASP.NET Core con Razor Pages

Base de Datos: SQL Server

ORM: Entity Framework (Code First)

Frontend: HTML, CSS, Bootstrap

Gesti�n de Autenticaci�n: ASP.NET Identity

## Funcionalidades Principales

Gesti�n de Estudiantes, Carreras, Cursos y Docentes.

CRUD completo para la administraci�n de datos.

Autenticaci�n y autorizaci�n con roles mediante ASP.NET Identity.

Migraciones para la estructuraci�n de la base de datos.

Interfaz responsiva con Bootstrap.

## Estructura del Proyecto

 Proyecto
	   Controllers          # Controladores para la gesti�n de datos
	   Views                # Vistas en Razor Pages
	   wwwroot              # Archivos est�ticos (CSS, JS, im�genes)
	   Models               # Modelos de datos
	   Data                 # Contexto y migraciones de base de datos
	   Migrations           # Migraciones de Entity Framework
	   Services             # Servicios de aplicaci�n
	   Identity             # Implementaci�n de autenticaci�n y roles
	   appsettings.json     # Configuraci�n de la aplicaci�n
	   Program.cs           # Configuraci�n del servidor
	   Startup.cs           # Configuraci�n de middleware y servicios

## Instalaci�n y Configuraci�n

Clonar el repositorio:

git clone https://github.com/kemeldev/MatriculaU_BolanosKevin

Abrir el proyecto en Visual Studio 2022.

Configurar la cadena de conexi�n en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;Trusted_Connection=True;"
}

Ejecutar las migraciones para crear la base de datos:

dotnet ef database update

Ejecutar la aplicaci�n:

dotnet run

## Uso

Accede a la aplicaci�n desde el navegador en http://localhost:5000.

Registra un usuario y accede con sus credenciales.

Gestiona carreras, estudiantes y profesores desde el panel de administraci�n.

## Contribuci�n

Las contribuciones son bienvenidas. Para colaborar:

Realiza un fork del repositorio.

Crea una nueva rama (feature/nueva-funcionalidad).

Realiza tus cambios y haz un commit.

Env�a un pull request.

## Licencia

Este proyecto est� bajo la licencia MIT. Para m�s detalles, revisa el archivo LICENSE.

Proyecto desarrollado para la gesti�n eficiente de matr�culas universitarias.