# C# Minesweeper Konsolenanwendung

## Übersicht
Das Projekt **MineSweeper** ist eine objektorientierte C#-Konsolenanwendung des Spieleklassikers Minesweeper.

## Projektstruktur & Architektur
- `Program.cs`: Haupteinstiegspunkt der Anwendung und Spielschleife.
- `Game.cs`: Steuerung der Spiellogik, Zugverarbeitung und Spielzustände.
- `Spielfeld.cs`: Datenstruktur zur Darstellung des Gitters und der Minenverteilung.
- `Render.cs`: Komponente zur Konsolen-Ausgabe und visuellen Darstellung des Feldes.
- `Level.cs` & `User.cs`: Verwaltung von Schwierigkeitsgraden und Benutzerzugriffen.

## Hauptfunktionalitäten
- **Objektorientierter Aufbau**: Klare Trennung von Spiellogik, Spielfeld und Visualisierung.
- **Schwierigkeitsgrade**: Auswahl verschiedener Feldgrössen und Minendichten.
- **Konsolen-Visualisierung**: Dynamische Aktualisierung der Anzeige bei Spielzügen.

## Ausführung & Nutzung
Das Spiel wird nach Kompilierung der `.csproj`-Datei mit `dotnet run` in der Konsole gestartet.

## Lizenz
Dieses Projekt steht unter der MIT-Lizenz.
