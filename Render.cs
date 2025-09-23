namespace Minesweeper
{
    public class Render
    {
        public void Draw(Spielfeld sf)
        {
            Console.Clear();
            Console.Write("   ");

            for (int x = 0; x < sf.Size; x++)
            {
                Console.Write((char)('A' + x) + " ");
            }

            Console.WriteLine();

            for (int y = 1; y <= sf.Size; y++)
            {
                if (y < 10)
                {
                    Console.Write(" " + y + " ");
                }
                else
                {
                    Console.Write(y + " ");
                }

                for (int x = 0; x < sf.Size; x++)
                {
                    string name = ((char)('A' + x)).ToString() + y;
                    var feld = sf.Get(name);
                    string symbol = feld.Item1;
                    ConsoleColor color = feld.Item2;

                    Console.ForegroundColor = color;
                    Console.Write(symbol + " ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}