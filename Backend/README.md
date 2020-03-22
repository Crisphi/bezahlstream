# Migrations

## Go to the api directory
```bash
cd ./src/BezahlStream.Backend.Api/
```
## Run migration for the grant store
```bash
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
```
## Run migration for the configuration store
```bash
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
```
## Finally run the migration for the ApplicationDbContext
```bash
dotnet ef migrations add IdentityAppDbContext -c AppDbContext -o Data/Migrations/Identity/AppDb
```
