using RandomProjec;

namespace stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();

            GameLogic gameLogic = new GameLogic();

            gameLogic.StartGame();
        }
    }
}