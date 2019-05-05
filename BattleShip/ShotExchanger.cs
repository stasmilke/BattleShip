using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;

namespace BattleShip
{
    public class ShotExchanger
    {
        //public delegate void ShotDelegate(Point point, bool isFirstPlayer);
        //public delegate void ShotMessage();

        //public static event ShotMessage ShotHasMade;
        //public static event ShotDelegate Shot;

        private static StatedButtonControl[,] player;
        private static StatedButtonControl[,] computer;

        private int playerLeft;
        private int computerLeft;

        private readonly Random rnd;

        private List<Point> points;

        private Direction direction;

        private GameWindow gameWindow;

        public ShotExchanger(StatedButtonControl[,] arrPlayer, StatedButtonControl[,] arrComputer, GameWindow window)
        {
            player = arrPlayer;
            computer = arrComputer;
            //Shot += CheckShot;
            computerLeft = 20;
            playerLeft = 20;
            rnd = new Random();
            points = new List<Point>(6);
            gameWindow = window;
        }

        public void CheckShot(Point point, bool isComputer)
        {
            StatedButtonControl button = isComputer ? player[(int)point.X, (int)point.Y] : computer[(int)point.X, (int)point.Y];
            if (button.button.ButtonState == StatedButton.State.Ship
                || button.button.ButtonState == StatedButton.State.HidenShip)
            {
                button.button.ButtonState = StatedButton.State.Killed;
                button.button.LinkedShip.Decrement();
                if (button.button.LinkedShip.Left == 0)
                {
                    //Убит
                }
                else
                {
                    //Ранен
                }
                if (isComputer)
                {
                    playerLeft--;
                }
                else
                {
                    computerLeft--;
                }
                if (computerLeft == 0)
                {
                    MessageBox.Show("Вы победили!");
                    gameWindow.Close();
                } 
                if (playerLeft == 0)
                {
                    MessageBox.Show("Победил компьютер");
                    gameWindow.Close();
                }
            }
            else if (button.button.ButtonState == StatedButton.State.Unselected || button.button.ButtonState == StatedButton.State.Locked)
            {
                button.button.ButtonState = StatedButton.State.Missed;
                //Промазал
            }

            if (isComputer)
            {
                if (button.button.ButtonState == StatedButton.State.Missed)
                {
                    if (points.Count > 2)
                    {
                        switch (direction)
                        {
                            case Direction.Down:
                                direction = Direction.Up;
                                break;
                            case Direction.Up:
                                direction = Direction.Down;
                                break;
                            case Direction.Left:
                                direction = Direction.Right;
                                break;
                            case Direction.Right:
                                direction = Direction.Left;
                                break;
                        }
                        points.RemoveRange(1, points.Count - 1);
                    }
                    else if (points.Count == 2)
                    {
                        points.RemoveAt(1);
                        direction++;
                    }
                    else
                    {
                        points.Clear();
                    }
                }
                if (button.button.ButtonState == StatedButton.State.Killed)
                {
                    if (button.button.LinkedShip.Left == 0)
                    {
                        points.Clear();
                        direction = 0;
                    }
                }
            }
            
            if (!isComputer)
            {
                CheckShot(GetRandomPoint(), true);
            }
        }

        private Point GetRandomPoint()
        {
            Point point;
            if (points.Count == 0)
            {
                direction = Direction.Left;
                StatedButtonControl btn;
                do
                {
                    point = new Point(rnd.Next(0, 10), rnd.Next(0, 10));
                }
                while ((btn = player[(int)point.X, (int)point.Y]).button.ButtonState == StatedButton.State.Missed
                     || btn.button.ButtonState == StatedButton.State.Killed);
            }
            else
            {
                Point oldPoint = points[points.Count - 1];
                StatedButtonControl btn;
                while (((point = GetNextPoint(oldPoint)).X > 9 || point.Y > 9 || point.X < 0 || point.Y < 0 ||
                    (btn = player[(int)point.X, (int)point.Y]).button.ButtonState == StatedButton.State.Missed
                    || btn.button.ButtonState == StatedButton.State.Killed ) && (int) direction < 4)
                {
                    direction++;
                }
            }
            points.Add(point);
            return point;
        }

        private Point GetNextPoint(Point oldPoint)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(oldPoint.X - 1, oldPoint.Y);
                case Direction.Up:
                    return new Point(oldPoint.X, oldPoint.Y + 1);
                case Direction.Right:
                    return new Point(oldPoint.X + 1, oldPoint.Y);
                default:
                    return new Point(oldPoint.X, oldPoint.Y - 1);
            }
        }

        private enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }
    }
}
