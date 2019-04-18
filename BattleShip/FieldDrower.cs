using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace BattleShip
{
    class FieldDrower
    {
        public static StatedButtonControl[,] CreateEmptyField(GameWindow window)
        {
            StatedButtonControl[,] buttons = new StatedButtonControl[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new StatedButtonControl();
                    buttons[i, j].Tag = new Point(i, j);
                }
            }
            return buttons;
        }
    }
}
