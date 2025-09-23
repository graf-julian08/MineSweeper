namespace Minesweeper
{
    public class Spielfeld
    {
        private Dictionary<string, (string, ConsoleColor)> punkte = new Dictionary<string, (string, ConsoleColor)>();
        private List<string> felder = new List<string>();
        private List<string> bomben = new List<string>();
        private List<string> flags = new List<string>();
        private List<string> geoeffnet = new List<string>();
        private Random rnd = new Random();

        public int Size { get; private set; }
        public IReadOnlyList<string> Bomben => bomben;
        public IReadOnlyList<string> Flags => flags;
        public IReadOnlyList<string> Geoeffnet => geoeffnet;

        public Spielfeld(int size)
        {
            Size = size;
            Init();
            SetBombs();
        }

        private void Init()
        {
            for (int y = 1; y <= Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    string name = ((char)('A' + x)).ToString() + y;
                    punkte[name] = (".", ConsoleColor.White);
                    felder.Add(name);
                }
            }
        }

        private void SetBombs()
        {
            int count = (int)Math.Round(Size * Size * 0.16);
            if (count < 1)
            {
                count = 1;
            }

            while (bomben.Count < count)
            {
                string feld = felder[rnd.Next(felder.Count)];

                if (!bomben.Contains(feld))
                {
                    bomben.Add(feld);
                }
            }
        }

        public void Render()
        {
            Render render = new Render();
            render.Draw(this);
        }

        public void RenderAgain()
        {
            Render();
        }

        public bool IsCoordinate(string name)
        {
            return punkte.ContainsKey(name);
        }

        public void MarkOpened(string name)
        {
            if (!geoeffnet.Contains(name))
            {
                geoeffnet.Add(name);
            }
        }

        public void SetFlag(string name)
        {
            if (geoeffnet.Contains(name))
            {
                return;
            }

            if (flags.Contains(name))
            {
                punkte[name] = (".", ConsoleColor.White);
                flags.Remove(name);
            }
            else if (flags.Count < bomben.Count)
            {
                punkte[name] = ("F", ConsoleColor.Yellow);
                flags.Add(name);
            }

            RenderAgain();
        }

        public void RemoveFlag(string name)
        {
            if (flags.Contains(name))
            {
                punkte[name] = (".", ConsoleColor.White);
                flags.Remove(name);
                RenderAgain();
            }
        }

        public (string, ConsoleColor) Get(string name)
        {
            return punkte[name];
        }

        public List<string> GetNeighbors(string name)
        {
            List<string> nachbarn = new List<string>();
            char col = name[0];
            int row = int.Parse(name.Substring(1));

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                    {
                        continue;
                    }

                    char newCol = (char)(col + dx);
                    int newRow = row + dy;

                    if (newCol >= 'A' && newCol < 'A' + Size && newRow >= 1 && newRow <= Size)
                    {
                        string neighbor = newCol.ToString() + newRow;

                        if (IsCoordinate(neighbor))
                        {
                            nachbarn.Add(neighbor);
                        }
                    }
                }
            }

            return nachbarn;
        }

        public int CountBombs(string name)
        {
            int count = 0;

            foreach (string n in GetNeighbors(name))
            {
                if (bomben.Contains(n))
                {
                    count++;
                }
            }

            return count;
        }

        public void ShowBombs()
        {
            foreach (string b in bomben)
            {
                punkte[b] = ("B", ConsoleColor.Red);
            }

            RenderAgain();
        }

        public void OpenField(string name)
        {
            if (geoeffnet.Contains(name))
            {
                return;
            }

            MarkOpened(name);
            int count = CountBombs(name);

            if (count > 0)
            {
                punkte[name] = (count.ToString(), ConsoleColor.Green);
            }
            else
            {
                punkte[name] = (" ", ConsoleColor.Gray);

                foreach (string n in GetNeighbors(name))
                {
                    if (!geoeffnet.Contains(n) && !bomben.Contains(n))
                    {
                        OpenField(n);
                    }
                }
            }
        }
    }
}