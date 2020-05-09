# Cei.Api.Common

> .NET standard 2.0 Class Library

Release 1.0.0

Librería general de uso compartido para desarrollo de Endpoints de la API del CEI en ASP.NET Web API

## Auth 
Atributo para propocionar authentication via Api Key. Requiere implementar `Cei.Api.Common.Models.CeiApiKey` como Dependency Injection para leer *appsettings.json* (ver Settings)

#### Implementación

```c#
using Cei.Api.Common.Auth
. . .
[ApiKeyAuth]
public class EndpointController : ControllerBase
{
    . . .
}
```

## Modelos

### Data Binding
Clases para mapear y validar modelos a la base de Mongo DB
```c#
Cei.Api.Common.Models.Estudiante
Cei.Api.Common.Models.Materia
Cei.Api.Common.Models.Encuesta
Cei.Api.Common.Models.EncuestaRespuesta
```

## Settings
Clases para configurar Inyección de depedencias de appsettings.
```c#
Cei.Api.Common.Models.CeiApiDB
Cei.Api.Common.Models.CeiApiKey
```

#### Implementación con Dependency Injection

*Startup.cs*

```c#
using  Cei.Api.Common.Models
. . .
public class Startup
{
    . . . 
    public void ConfigureServices(IServiceCollection services)
    {
        . . .
        // Settings Config            
        services.Configure<CeiApiDB>(Configuration.GetSection(nameof(CeiApiDB)));
        services.Configure<CeiApiKey>(Configuration.GetSection(nameof(CeiApiKey)));

        // Settings Dependency Injection 
        services.AddSingleton<ICeiApiDB>(sp => sp.GetRequiredService<IOptions<CeiApiDB>>().Value);
        services.AddSingleton<ICeiApiKey>(sp => sp.GetRequiredService<IOptions<CeiApiKey>>().Value);
        . . .
    }
    . . .
}
```

*appsettings.json*
```c#
{
  . . .
  "CeiApiDB": {
    "ConnectionString": "user-secrets|env",
    "DatabaseName": "cei_api",
    "Collections": {
      "Curso": "cursos",
      "Estudiante": "estudiantes",
      "Materia": "materias",
      "Encuesta": "encuestas",
      "EncuestaRespuesta": "encuestas_respuestas"
    }
  },
  "CeiApiKey": {
    "Current": "user-secrets|env",
    "Academica": "user-secrets|env"
  }
  . . . 
}
```
**¡Importante!** 

Por razones de seguridad Setear *ConnectionString* y las *CeiApiKey* por user-secrets de .NET o por variables de entorno.

## Servicios

***MongoCrudService***

```c#
Cei.Api.Common.services.MongoCrudService
```

Servicio de uso general para manejo de datos en MongoDB.
Brinda funcionalidad para operacion CRUD.

Funcionalidades:
- Operaciones base Create, Update y Delete
- Busqueda por *Id*, *lambda expressions* y *full text search* segun configuración de Mongo DB
- Funciones asincronas (retornan Task)
- Cada método Soporta MongoDB Projections via Generics.



#### implementación con Dependency Injection

*En capa de servicios*

```c#
using Cei.Api.Common.Services;
using Cei.Api.Common.Models;

public class ModeloService : MongoCrudService<Modelo>
{
    public ModeloService(ICeiApiDB dbSettings) :
        base(dbSettings, dbSettings.Collections.Modelo)
    {
      //agregar metodos personalizados si es necesario
      . . .
    }
}

```

*Startup.cs*

```c#
public class Startup
{
    . . . 
    public void ConfigureServices(IServiceCollection services)
    {
        . . .
        services.AddSingleton<ICrudService<Modelo>, ModeloService>();
        . . .
    }
    . . .
}
```
