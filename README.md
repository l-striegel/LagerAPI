# LagerAPI

Eine RESTful-Schnittstelle zur Verwaltung von Lagerbeständen und Artikeldaten. Entwickelt mit ASP.NET Core und PostgreSQL.

## Features

- CRUD-Operationen für Artikel
- Bestandsverfolgung
- Formatierungsinformationen für Artikel
- Versionskontrolle über Zeitstempel
- Swagger-UI für API-Dokumentation und Tests

## Installation

1. Repository klonen
2. `.env.example` zu `.env` kopieren und Datenbankeinstellungen anpassen
3. `dotnet run` ausführen

## API-Endpunkte

- `GET /api/Article` - Alle Artikel abrufen
- `GET /api/Article/{id}` - Einen Artikel abrufen
- `POST /api/Article` - Neuen Artikel erstellen
- `PUT /api/Article/{id}` - Artikel aktualisieren
- `DELETE /api/Article/{id}` - Artikel löschen