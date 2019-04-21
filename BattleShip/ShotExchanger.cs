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
        public delegate void ShotDelegate(Point point, bool isFirstPlayer);
        public delegate void ShotMessage();

        public static event ShotMessage ShotHasMade;
        public static event ShotDelegate Shot;

        private static StatedButtonControl[,] player;
        private static StatedButtonControl[,] computer;

        private int playerLeft;
        private int computerLeft;

        public ShotExchanger(StatedButtonControl[,] arrPlayer, StatedButtonControl[,] arrComputer)
        {
            player = arrPlayer;
            computer = arrComputer;
            Shot += CheckShot;
            computerLeft = 20;
            playerLeft = 20;
        }

        public void CheckShot(Point point, bool isComputer)
        {
            StatedButtonControl button = isComputer ? player[(int)point.X, (int)point.Y] : computer[(int)point.X, (int)point.Y];
            Thread.Sleep(1000);
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
                    //Победил игрок
                } 
                if (playerLeft == 0)
                {
                    //Победил компьютер
                }
            }
            else if (button.button.ButtonState == StatedButton.State.Unselected
                     || button.button.ButtonState == StatedButton.State.Locked)
            {
                button.button.ButtonState = StatedButton.State.Missed;
                //Промазал
            }

        }
    }
}
