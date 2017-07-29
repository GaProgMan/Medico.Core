## Migrations

### Create a migration from this project 

> dotnet ef migrations add NameOfMigration

### Update the database

> dotnet ef database update

### Pulling database into UI project

Whenever a `dotnet restore` or a `dotnet build` are performed on teh UI project, the latest database file will be pulled through to the relevant bin folder for the UI project.

(assuming that the UI project references this project correctly)