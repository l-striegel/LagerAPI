# LagerAPI

Eine RESTful-Schnittstelle zur Verwaltung von Lagerbeständen und Artikeldaten. Entwickelt mit ASP.NET Core und PostgreSQL.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![Status](https://img.shields.io/badge/Status-Stable-green)

## Features

- CRUD-Operationen für Artikel
- Bestandsverfolgung
- Formatierungsinformationen für Artikel
- Versionskontrolle über Zeitstempel
- Swagger-UI für API-Dokumentation und Tests
- Konfliktlösung bei parallelen Änderungen

## Installation

1. Repository klonen: `git clone https://github.com/l-striegel/LagerAPI.git`
2. `.env.example` zu `.env` kopieren und Datenbankeinstellungen anpassen
3. `dotnet run` ausführen
4. Swagger UI unter `https://localhost:5001/swagger` aufrufen

## API-Endpunkte

- `GET /api/Article` - Alle Artikel abrufen
- `GET /api/Article/{id}` - Einen Artikel abrufen
- `POST /api/Article` - Neuen Artikel erstellen
- `PUT /api/Article/{id}` - Artikel aktualisieren
- `DELETE /api/Article/{id}` - Artikel löschen

## Kompatible Clients

Diese API ist voll kompatibel mit den folgenden Client-Anwendungen:

### LagerClient Blazor

Eine moderne Blazor WebAssembly-Anwendung mit Excel-ähnlicher Bearbeitung und Offline-Fähigkeit:
- Repository: [https://github.com/l-striegel/LagerClientBlazor](https://github.com/l-striegel/LagerClientBlazor)
- Live-Demo: [https://l-striegel.github.io/LagerClientBlazor/](https://l-striegel.github.io/LagerClientBlazor/)
- Features: Excel-ähnliche Tabellendarstellung, Offline-Modus, automatische Synchronisierung

### LagerClient Java

Eine Java-Desktop-Anwendung zur Verwaltung von Lagerartikeln:
- Repository: [https://github.com/l-striegel/LagerClient-Java](https://github.com/l-striegel/LagerClient-Java)
- Features: Benutzerfreundliche UI, Echtzeit-Formatierung, HTTP-Backend-Anbindung

## Technologie-Stack

- ASP.NET Core 8.0
- Entity Framework Core
- PostgreSQL
- Swagger/OpenAPI
- Docker-Unterstützung

## Artikelmodell

```csharp
public class Article
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Stock { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public string Link { get; set; }
    public string StylesJson { get; set; }
    public DateTime LastModified { get; set; }
}
```

## Formatierungsinformationen

Die API unterstützt das Speichern von UI-spezifischen Formatierungsinformationen im `StylesJson`-Feld, das JSON-Daten für Zellenformatierung in den Client-Anwendungen enthält.
