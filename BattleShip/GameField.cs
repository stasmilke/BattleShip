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
        private List<StatedButton> buttons;
        private ShipCollection shipToSet;

        public GameField()
        {
            buttons = new List<StatedButton>(4);
            shipToSet = new ShipCollection();
        }

        public void SetShipState(StatedButtonControl sender)
        {
            bool isFail = false;
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
                              ? sender.ThisField.PlayerField[(int)point.X, shipPoint + i]
                              : sender.ThisField.PlayerField[shipPoint + i, (int)point.Y];
                if (buttonControl.button.ButtonState == StatedButton.State.Unselected)
                {
                    buttonControl.button.ButtonState = StatedButton.State.SetShip;
                    buttons.Add(buttonControl.button);
                }
                else
                {
                    isFail = true;
                    break;
                }
            }
            if (isFail)
            {
                UnsetShipState();
            }
        }

        public void UnsetShipState()
        {
            foreach (StatedButton btn in buttons)
            {
                btn.ButtonState = StatedButton.State.Unselected;
            }
            buttons.Clear();
        }

        public void SetShipOnField()
        {
            Ship ship = shipToSet.GetShip(buttons.Count);
            if (ship != null)
            {
                int index = 0;
                foreach (StatedButton btn in buttons)
                {
                    btn.ButtonState = StatedButton.State.Ship;
                    btn.LinkedShip = ship;
                    ship.Position[index++] = btn;
                }
                buttons.Clear();
            }
        }

        public void UnsetShipOnField(Ship ship, StatedButtonControl sender)
        {
            foreach (StatedButton btn in ship.Position)
            {
                btn.ButtonState = StatedButton.State.Unselected;
                btn.LinkedShip = null;
            }
            shipToSet.ReturnShip(ship);
            SetShipState(sender);
        }





        //Отключение соседних с кораблем клеток
        private void TurnOffNear()
        {

        }

        private void TurnOnNear()
        {

        }
    }
}
