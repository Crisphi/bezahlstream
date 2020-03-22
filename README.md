# Onstayge - Die Streamingplattform für Kulturschaffende

Onstayge ist ein, im Rahmen des Hackathons #WirVsVirus der Bundesregierung, entstandenes Projekt, mit dem Kulturschaffende ihre Videos monetarisiert zur Verfügung stellen können. 
Für mehr Informationen: [Devpost Seite des Projekts](https://devpost.com/software/025_e-kulturangebote_bezahlstreamtheaterkonzerte "devpost.com")






# Notes for Developers 

migration command, to run in database folder
dotnet ef migrations add Init --startup-project ..\BezahlStream.Backend.Api\

## Required
dotnet tool install --global dotnet-ef
