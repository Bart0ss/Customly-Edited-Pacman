using System;
using static Customly_Edited_Pacman.Map;
using static Customly_Edited_Pacman.Game;

namespace Customly_Edited_Pacman
{
    class Core
    {
        public static string[,] _Map;
        public static Player player = new Player(0, 0);
        public static Player player2 = new Player(0, 0);
        public static int max_points_on_current_maze;

        public static void Main(string[] args)
        {
            int height = 10;
            int width = 10;

            _Map = create_2D_array(height, width);
            _Map = createBorder(_Map);

            while (true)
            {
                // setup
                resetMap(height, width);
                bool gameIsOver = false;
                max_points_on_current_maze = amount_of_points_on_map(_Map);
                // end setup
                while (!gameIsOver)
                {
                    showGameInfo();
                    showWarnings();
                    showMap(_Map);
                    whoWon(height,width);

                    var key = Console.ReadKey().Key;
                    Player currentPlayer = Movement.WhoUsedKey(key);
                    Direction determined = Movement.DetermineDirection(key);
                    if (max_points_on_current_maze == 0 || !Movement.PlayerMovement(currentPlayer,determined) 
                                                        || key==ConsoleKey.Escape)
                    {
                        gameIsOver = true;
                    }

                    Console.Clear();
                }
            }
        }
    }
}
