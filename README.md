# 📖 Bible Study Platform
 
<div align="center">
 
![.NET](https://img.shields.io/badge/.NET_8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Blazor](https://img.shields.io/badge/Blazor_WASM-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
 
**A backend-first web platform for studying the Bible — built with Clean Architecture, multiple translations, and a rich feature roadmap.**
 
</div>
 
---
 
## What Is This?
 
Bible Study Platform is not just a Bible reader.  
It's a full study environment — built the way a real commercial product should be.
 
The goal is to provide a structured, extensible backend that supports:
 
- Reading scripture across multiple translations
- Scholarly commentaries and study media (maps, diagrams)
- User-driven features: highlights, notes, emoji reactions
- Reading plans with progress tracking
- Personal reading statistics
 
> Backend is the product. The frontend is a client.
 
---
 
## Architecture
 
The project follows **Clean Architecture** — strictly layered, with clear boundaries and no circular dependencies.
 
```
src/
├── BibleStudy.Core/           # Domain models, interfaces, DTOs, Result pattern
├── BibleStudy.Application/    # Use cases, services, business logic
├── BibleStudy.Persistence/    # EF Core, repositories, migrations
├── BibleStudy.Infrastructure/ # Auth, file storage, background services
└── BibleStudy.API/            # Controllers, validation, HTTP layer
 
frontend/
├── web-blazor/                # Temporary Blazor WASM client
└── web-js/                    # Future React / Next.js frontend
 
tests/                         # Unit and integration tests (coming soon)
```
 
### Key Design Decisions
 
| Decision | Choice | Why |
|---|---|---|
| Error handling | `Result<T>` pattern | Explicit, no silent failures |
| Validation | FluentValidation in API layer | Clean separation from business logic |
| Response errors | Unified `ProblemDetails` format | Consistent API contract |
| ORM | EF Core with raw queries where needed | Flexibility without losing type safety |
| DTO location | `Core` layer | Contracts belong to the domain, not infrastructure |
 
---
 
## API Overview
 
All endpoints follow REST conventions. Errors always return `ProblemDetails` with a consistent `errors` array.
 
### Scripture
 
```http
GET /api/chapters?translationAbbrev=ASV&book=Genesis&chapter=1
GET /api/verses?translationAbbrev=ASV&book=Genesis&chapter=1&verseNumber=1
```
 
### Error Response Format
 
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred",
  "status": 400,
  "errors": [
    {
      "code": "Book.NotFound",
      "description": "Book 'Genesis2' is not a valid Bible book name"
    }
  ]
}
```
 
---
 
## Tech Stack
 
| Layer | Technology |
|---|---|
| Runtime | .NET 8 |
| Language | C# 12 |
| Database | PostgreSQL |
| ORM | Entity Framework Core |
| Validation | FluentValidation |
| Temporary UI | Blazor WebAssembly |
| Future UI | React / Next.js |
 
---
 
## Current Status
 
| Feature | Status |
|---|---|
| `GET /api/chapters` — read full chapter | ✅ Done |
| `GET /api/verses` — read single verse | ✅ Done |
| Blazor UI — displays scripture text | ✅ Done |
| Multiple translations | 🔄 In progress |
| Unified error format | 🔄 In progress |
| Commentaries & media | 📋 Planned |
| Auth + user accounts | 📋 Planned |
| Notes, highlights, emoji reactions | 📋 Planned |
| Reading plans | 📋 Planned |
| Reading statistics | 📋 Planned |
 
---
 
## Getting Started
 
### Prerequisites
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/)
 
### Setup
 
```bash
git clone https://github.com/Cheer5ul/bible-study.git
cd bible-study
```
 
Configure your connection string in `src/BibleStudy.API/appsettings.Development.json`:
 
```json
{
  "ConnectionStrings": {
    "BibleStudyDbContext": "Host=localhost;Database=biblestudy;Username=postgres;Password=yourpassword"
  }
}
```
 
Apply migrations and run:
 
```bash
cd src/BibleStudy.API
dotnet ef database update
dotnet run
```
 
API will be available at `https://localhost:5246/swagger`
 
---
 
## Roadmap
 
```
Phase 1 — Scripture        ← current
Phase 2 — Study Content    (commentaries, media, cross-references)
Phase 3 — User Features    (auth, notes, highlights, emoji)
Phase 4 — Reading Plans    (plans, progress tracking)
Phase 5 — Statistics       (reading analytics)
```
 
---
 
<div align="center">
 
Built as a real-world backend project — not a tutorial, not a CRUD demo.
 
</div>
