namespace Minesweeper
{
    public class Game
    {
        public void Start()
        {
            int size = Level.ChooseLevel();

            Spielfeld field = new Spielfeld(size);
            field.Render();

            User user = new User();
            user.Input(field);
        }
    }
}