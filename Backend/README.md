# Migrations
dotnet ef 

cd ./src/BezahlStream.Backend.Api/
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
dotnet ef migrations add IdentityAppDbContext -c AppDbContext -o Data/Migrations/Identity/AppDb