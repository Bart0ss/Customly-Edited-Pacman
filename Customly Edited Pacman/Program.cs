using System;
using static Customly_Edited_Pacman.Map;
using static Customly_Edited_Pacman.Game;
namespace Customly_Edited_Pacman
{
    class Program
    {
        public static string[,] arr;
        public static Player player = new Player(0, 0);
        public static int max_points_on_current_maze;
        public static void Main(string[] args)
        {
            int height = 10;
            int width = 10;
            arr = create_2D_array(height, width);
            arr = createBorder(arr);

            while (true)
            {
                arr = CreateMaze(arr);
                player.setCoords(height / 2, width / 2);
                bool gameIsOver = false;
                max_points_on_current_maze = amount_of_points_on_map(arr);
                while (!gameIsOver)
                {
                    Console.WriteLine(player.getScore());
                    Console.WriteLine(max_points_on_current_maze);

                    ShowWarnings();
                    ShowMap(arr);
                    var key = Console.ReadKey().Key;

                    if (max_points_on_current_maze == 0 || !Movement.PlayerMovement(key))
                    {
                        gameIsOver = true;
                    }
                    Console.Clear();

                    /*
                        *  Player currentPlayer = player;
                        player1Keys.Contains(key) ? Player.Player1 :
                        (player2Keys.Contains(key) ? Player.Player2 : Player.Empty);
                    */

                }
            }
        }
    }
}
