namespace Minesweeper
{
    public class Level
    {
        public static int ChooseLevel()
        {
            Console.WriteLine("TUTORIAL\n\nZiel: Alle sicheren Felder aufdecken, ohne eine Mine zu treten.\n\nAblauf:\nZuerst wählt man den Schwierigkeitsgrad, dadurch ändert sich die Spielfeldgrösse.\nDanach gibt man unten Koordinaten ein, um Felder aufzudecken.\n\t- Wird eine Zahl angezeigt, zeigt sie an, wie viele Minen in der Nähe liegen.\n\t- Gibt man neben den Koordinaten ein F ein (z.B. a1F), markiert man das Feld.\n\nRegeln:\nDeckt man ein Feld mit einer Mine auf, hat man verloren.\n\nFarben: \nMarkierte Minen werden gelb hervorgehoben. Tritt man auf eine Mine, werden alle Minen rot angezeigt.\n\n");

            int size = 0;
            bool chosen = false;

            while (!chosen)
            {
                Console.WriteLine("Schwierigkeitsgrad: Einfach, mittel oder schwierig?");
                string input = (Console.ReadLine() ?? "").ToLower();

                switch (input)
                {
                    case "einfach":
                        size = 8;
                        chosen = true;
                        break;

                    case "mittel":
                        size = 16;
                        chosen = true;
                        break;

                    case "schwierig":
                        size = 26;
                        chosen = true;
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte erneut versuchen.");
                        break;
                }
            }

            return size;
        }
    }
}