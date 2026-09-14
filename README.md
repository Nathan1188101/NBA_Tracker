# NBA_Tracker

This app will allow you to organize NBA Game Dates, Players, and Stats all into one place.
Keep track of the games YOU care about within my NBA TRACKER — enter a game with who's playing, the date and time of when the game starts, as well as the location of the game.
Additionally you can enter specific Players you'd like to keep track of and enter their stats after a game to see a history of how they have been playing.

With all these options in front of you, it will be easy to keep track of the games and players you care about and access it all in one easy place.

## Built with

- **ASP.NET Core MVC** (.NET 7), C#
- **Entity Framework Core 7** with **SQL Server**, using code-first migrations
- **ASP.NET Core Identity** for accounts, with **Google OAuth** as an external login provider
- **MSTest** unit tests running against an in-memory EF Core provider
- **Azure App Service**, deployed by **GitHub Actions**

## Data model

Four entities drive the app:

| Entity | Purpose |
| --- | --- |
| `Team` | NBA teams |
| `Player` | Players, each belonging to a team |
| `Game` | A scheduled game — teams playing, date/time, location |
| `GamePlayerStats` | Links a player to a game, holding that player's stats for that specific game |

Splitting `GamePlayerStats` out from `Player` is what makes the stat history work: numbers are recorded per appearance rather than as a single running total on the player, so you can look back at how someone has played game by game.

The class diagram is in [`NBA Model Classes.drawio.pdf`](./NBA%20Model%20Classes.drawio.pdf).

## Project layout

```
NBA_Tracker/          ASP.NET Core MVC app
  Controllers/        Games, Players, Teams, GamePlayerStats, Home
  Models/             Game, Player, Team, GamePlayerStats
  Data/               ApplicationDbContext
  Migrations/         EF Core code-first migrations
  Areas/Identity/     Identity UI
  Views/  wwwroot/
NBA_APP_Testing/      MSTest project (GamesControllerTests)
.github/workflows/    GitHub Actions build + deploy to Azure
```

The CRUD controllers and Razor views were generated with the ASP.NET scaffolding tooling from the EF Core model; the data model, authentication setup, tests and deployment pipeline were built on top of that.

## Deployment

This was deployed to Azure App Service at `nbatracker1.azurewebsites.net`. **That instance is no longer running, so the link is inactive** — the build and deploy workflows are still in `.github/workflows` if you want to see how it shipped.

## Running locally

Requires the .NET 7 SDK and a SQL Server instance (LocalDB is fine).

```bash
dotnet restore
dotnet ef database update --project NBA_Tracker
dotnet run --project NBA_Tracker
```

Configuration is kept out of source control with [User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) — you'll need to supply your own database connection string and Google OAuth client ID/secret:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your connection string>" --project NBA_Tracker
dotnet user-secrets set "Authentication:Google:ClientId" "<your client id>" --project NBA_Tracker
dotnet user-secrets set "Authentication:Google:ClientSecret" "<your client secret>" --project NBA_Tracker
```

---

Built for COMP2084G at Lakehead-Georgian, 2023.
