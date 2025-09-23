namespace Minesweeper
{
    public class User
    {
        private DateTime start;

        public void Input(Spielfeld sf)
        {
            start = DateTime.Now;

            Console.WriteLine("\nKoordinaten eingeben, um Feld aufzudecken (z.B. a1), Koordinaten + F eingeben, um Feld zu markieren (z.B. a1F).");
            Console.Write("Eingabe: ");

            bool playing = true;

            while (playing)
            {
                string input = (Console.ReadLine() ?? "").Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Ungültige Eingabe! Bitte erneut versuchen: ");
                }
                else if (input.EndsWith("f"))
                {
                    HandleFlag(sf, input);
                }
                else
                {
                    HandleOpen(sf, input, ref playing);
                } 
            }
        }

        private void HandleFlag(Spielfeld sf, string input)
        {
            string name = input.Substring(0, input.Length - 1).ToUpper();

            if (!sf.IsCoordinate(name))
            {
                Console.Write("Ungültige Eingabe! Bitte erneut versuchen: ");
                return;
            }

            if (sf.Flags.Contains(name))
            {
                sf.RemoveFlag(name);
            }
            else
            {
                sf.SetFlag(name);
            }

            Console.WriteLine("\nKoordinaten eingeben, um Feld aufzudecken (z.B. a1), Koordinaten + F eingeben, um Feld zu markieren (z.B. a1F).");
            Console.Write("Eingabe: ");
        }

        private void HandleOpen(Spielfeld sf, string input, ref bool playing)
        {
            string name = input.ToUpper();

            if (!sf.IsCoordinate(name))
            {
                Console.Write("Ungültige Eingabe! Bitte erneut versuchen: ");
                return;
            }

            if (sf.Flags.Contains(name))
            {
                Console.WriteLine(name + " ist geflaggt und kann nicht geöffnet werden.");
                Console.Write("Eingabe: ");
                return;
            }

            if (sf.Bomben.Contains(name))
            {
                sf.ShowBombs();
                EndGame(false, ref playing);
                return;
            }

            sf.OpenField(name);
            sf.RenderAgain();

            int safeFields = sf.Size * sf.Size - sf.Bomben.Count;

            if (sf.Geoeffnet.Count == safeFields)
            {
                sf.ShowBombs();
                EndGame(true, ref playing);
            }
            else
            {
                Console.WriteLine("\nKoordinaten eingeben, um Feld aufzudecken (z.B. a1), Koordinaten + F eingeben, um Feld zu markieren (z.B. a1F).");
                Console.Write("Eingabe: ");
            }
        }

        private void EndGame(bool win, ref bool playing)
        {
            DateTime end = DateTime.Now;
            TimeSpan duration = end - start;

            if (win)
            {
                Console.WriteLine("\nGlückwunsch, du hast gewonnen!");
            }
            else
            {
                Console.WriteLine("\nGAME OVER!");
            }

            Console.WriteLine($"Spielzeit: {duration:mm\\:ss}");

            bool decided = false;

            while (!decided)
            {
                Console.Write("\nMöchtest du erneut spielen? (ja/nein): ");
                string a = (Console.ReadLine() ?? "").Trim().ToLower();

                if (a == "ja")
                {
                    Console.Clear();
                    int size = Level.ChooseLevel();

                    Spielfeld field = new Spielfeld(size);
                    field.Render();

                    User user = new User();
                    user.Input(field);

                    decided = true;
                }
                else if (a == "nein")
                {
                    Console.WriteLine("Spiel beendet. Danke fürs Spielen!");
                    decided = true;
                    return;
                }
                else
                {
                    Console.WriteLine("Bitte 'ja' oder 'nein' eingeben!");
                }
            }

            playing = false;
        }
    }
}