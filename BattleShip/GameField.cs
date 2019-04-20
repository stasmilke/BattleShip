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
        private Random rnd;
        private bool isVertical;

        public GameField()
        {
            buttons = new List<StatedButton>(4);
            shipToSet = new ShipCollection();
            rnd = new Random();
        }

        public void SetShipState(StatedButtonControl sender)
        {
            isVertical = GameWindow.IsVertical;
            int length = GameWindow.SelectedLength;
            Point point = (Point)sender.Tag;
            StatedButtonControl[,] playerField = sender.ThisField.PlayerField;
            SetShipState(isVertical, length, point, playerField);
        }

        private bool SetShipState(bool isVertical, int length, Point point, StatedButtonControl[,] playerField)
        {
            bool isFail = false;
            StatedButtonControl buttonControl;
            int changablePos = (int)(isVertical ? point.Y : point.X);
            if (changablePos + length > 10)
            {
                changablePos -= changablePos + length - 10;
            }
            for (int i = 0; i < length; i++)
            {
                buttonControl = isVertical
                              ? playerField[(int)point.X, changablePos + i]
                              : playerField[changablePos + i, (int)point.Y];
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
            return isFail;
        }

        public void UnsetShipState()
        {
            foreach (StatedButton btn in buttons)
            {
                btn.ButtonState = StatedButton.State.Unselected;
            }
            buttons.Clear();
        }

        public void SetShipOnField(GameFieldElement gameField)
        {
            Ship ship = shipToSet.GetShip(buttons.Count);
            SetShipOnField(ship, isVertical, gameField);
        }

        public void SetShipOnField(Ship ship, bool isVertical, GameFieldElement gameField)
        {
            if (ship != null)
            {
                int index = 0;
                foreach (StatedButton btn in buttons)
                {
                    btn.ButtonState = StatedButton.State.Ship;
                    btn.LinkedShip = ship;
                    ship.Position[index++] = btn;
                }
                ship.IsVertical = isVertical;
                ChangeNearState(ship, gameField.PlayerField, false);
                buttons.Clear();
            }
        }

        public void UnsetShipFromField(Ship ship, StatedButtonControl sender)
        {
            foreach (StatedButton btn in ship.Position)
            {
                btn.ButtonState = StatedButton.State.Unselected;
                btn.LinkedShip = null;
            }
            shipToSet.ReturnShip(ship);
            ChangeNearState(ship, sender.ThisField.PlayerField, true);
            SetShipState(sender);
        }

        public void SetRandomShips(GameFieldElement gameField)
        {
            Ship thisShip;
            bool isVertical;
            Point point;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4 - j; i++)
                {
                    isVertical = rnd.Next(0, 2) == 1;
                    thisShip = shipToSet.GetShip(j + 1);
                    point = new Point(rnd.Next(0, 10), rnd.Next(0, 10));
                    while (SetShipState(isVertical, j + 1, point, gameField.PlayerField))
                    {
                        point = new Point(rnd.Next(0, 10), rnd.Next(0, 10));
                    }
                    SetShipOnField(thisShip, isVertical, gameField);
                }
            }
        }

        private void ChangeNearState(Ship ship, StatedButtonControl[,] playerField, bool unlock)
        {
            Point point;
            int shift;
            for (int i = 0; i < ship.Position.Length; i++)
            {
                point = (Point)ship.Position[i].Tag;
                if (i == 0)
                {
                    shift = -1;
                    Lock(point, ship, playerField, true, shift, unlock);
                }
                if (i == ship.Position.Length - 1)
                {
                    shift = 1;
                    Lock(point, ship, playerField, true, shift, unlock);
                }
                Lock(point, ship, playerField, false, -1, unlock);
                Lock(point, ship, playerField, false, 1, unlock);
            }

            
        }

        private void Lock(Point point, Ship ship, StatedButtonControl[,] playerField, bool invert, int shift, bool unlock)
        {
            try
            {
                StatedButtonControl control;
                control = ship.IsVertical ^ invert
                            ? playerField[(int)point.X + shift, (int)point.Y]
                            : playerField[(int)point.X, (int)point.Y + shift];
                if (control.button.ButtonState == StatedButton.State.Locked && unlock)
                {
                    control.button.ButtonState = StatedButton.State.Unselected;
                }
                if (control.button.ButtonState == StatedButton.State.Unselected && !unlock)
                {
                    control.button.ButtonState = StatedButton.State.Locked;
                }
            }
            catch (Exception) { }
        }
    }
}
