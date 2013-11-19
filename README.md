README

Detta är ett arbetsprov för Aditro AB, utfört av Erik Lindqvist.

Applikationen använder biblioteken AngularJS, Entity Framework, Json.NET. Installera via NuGet Package Manager om det skulle behövas.

LocalDB-databas finns i App_Data\EmployeeAPI1.mdf. Den är byggd med hjälp av Entity Framework Code First och Migrations. För att uppdatera databasen, kör kommandot Update-Database i Package Manager Console. Då skapas employee-tabellen om den inte finns och populeras med exempeldata om dessa inte redan finns. Seeds (exempeldata) finns i filen Migrations/Configuration.cs om man är sugen på att modifiera dessa.

API:et levererar data i både JSON och XML-format, och styrs via HTTP-headern "Accept", t.ex. "Accept: application/json", s.k. content negotiation. Google Chrome begär oftast data i XML-format, medans AngularJS-vyn ber om JSON.

AngularJS-modellen Employee innehåller inga fördefinierade medlemsvariabler för att inte upprepa koden. Istället utökas objektet med variablerna från JSON-datat. 
