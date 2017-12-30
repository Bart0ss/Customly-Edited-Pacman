using System;
using static Customly_Edited_Pacman.Core;
using static Customly_Edited_Pacman.Game;
using System.Linq;

namespace Customly_Edited_Pacman
{
    class Movement
    {
        public static Player WhoUsedKey(ConsoleKey key)
        {
            if (Game.player1Keys.Contains(key))
            {
                return Core.player;
            }
            else if (Game.player2Keys.Contains(key))
            {
                return Core.player2;
            }
              return Core.player;
        }

        public static Direction DetermineDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return Direction.North;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return Direction.South;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return Direction.West;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return Direction.East;

                case ConsoleKey.Home:
                case ConsoleKey.Q:
                    return Direction.NorthWest;

                case ConsoleKey.PageUp:
                case ConsoleKey.E:
                    return Direction.NorthEast;

                case ConsoleKey.End:
                case ConsoleKey.Z:
                    return Direction.SouthWest;

                case ConsoleKey.PageDown:
                case ConsoleKey.C:
                    return Direction.SouthEast;

                default:
                    return Direction.None;
            }
        }
        public static bool PlayerMovement(Player thisPlayer, Direction direction)
        {
            int new_x = 0;
            int new_y = 0;
            int currentX = thisPlayer.getCoorsX();
            int currentY = thisPlayer.getCoorsY();
            switch (direction)
            {
                case Direction.North:
                    new_x = currentX -1;
                    new_y = currentY;
                    break;
                case Direction.South:
                    new_x = currentX + 1;
                    new_y = currentY;
                    break;
                case Direction.East:
                    new_x = currentX;
                    new_y = currentY + 1;
                    break;
                case Direction.West:
                    new_x = currentX;
                    new_y = currentY - 1;
                    break;
                case Direction.NorthWest:
                    new_x = currentX - 1;
                    new_y = currentY - 1;
                    break;
                case Direction.NorthEast:
                    new_x = currentX -1;
                    new_y = currentY +1;
                    break;
                case Direction.SouthWest:
                    new_x = currentX +1;
                    new_y = currentY - 1;
                    break;
                case Direction.SouthEast:
                    new_x = currentX +1;
                    new_y = currentY + 1;
                    break;
                default:
                    bool contains = false;
                    foreach (var c in warnings)
                    {
                        if (c.Contains($@"Use < ^ > \/ arrows"))
                        {
                            contains = true;
                        }
                    }
                    if (!contains)
                    {
                        warnings.Add(@"Use < ^ > \/ arrows");
                    }
                    break;
            }
            if (Core._Map[new_x, new_y]== sign_point)
            {
                max_points_on_current_maze--;
                thisPlayer.increaseScore();
            }
            if (!unable_to_walk_thru_signs.Contains(Core._Map[new_x, new_y]))
            {
                Core._Map[currentX, currentY] = " ";
                Core._Map[new_x, new_y] = Game.sign_player;
                thisPlayer.setCoords(new_x, new_y);
            }
            return true;
        }
    }
}
