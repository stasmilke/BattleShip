using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BattleShip
{
    public class GameField
    {
        public bool isSetting;
        private static List<StatedButton> buttons;

        public GameField(bool isAuto)
        {
            isSetting = !isAuto;
        }

        static GameField()
        {
            buttons = new List<StatedButton>(4);
        }

        public static void SetShipState(StatedButtonControl sender)
        {
            Point point = (Point) sender.Tag;
            int shipPoint = (int) (GameWindow.IsVertical ? point.Y : point.X);
            if (shipPoint + GameWindow.SelectedLength > 10)
            {
                shipPoint -= shipPoint + GameWindow.SelectedLength - 10;
            }
            StatedButtonControl buttonControl;
            for (int i = 0; i < GameWindow.SelectedLength; i++)
            {
                buttonControl = GameWindow.IsVertical
                              ? GameWindow.PlayerField[(int)point.X, shipPoint + i]
                              : GameWindow.PlayerField[shipPoint + i, (int)point.Y];
                buttonControl.button.ButtonState = StatedButton.State.SetShip;
                buttons.Add(buttonControl.button);
            }
        }

        public static void UnsetShipState()
        {
            foreach (StatedButton btn in buttons)
            {
                btn.ButtonState = StatedButton.State.Unselected;
            }
            buttons.Clear();
        }

        public static void SetShipOnField()
        {

        }

        public static void UnsetShipOnField()
        {

        }
    }
}
