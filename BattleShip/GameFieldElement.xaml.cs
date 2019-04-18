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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShip
{
    /// <summary>
    /// Логика взаимодействия для GameFieldElement.xaml
    /// </summary>
    public partial class GameFieldElement : UserControl
    {
        public GameFieldElement()
        {
            InitializeComponent();
        }

        public static StatedButtonControl[,] CreateEmptyField()
        {
            StatedButtonControl[,] buttons = new StatedButtonControl[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new StatedButtonControl(new GameField(false));
                    buttons[i, j].Tag = new Point(i, j);
                }
            }
            return buttons;
        }
    }
}
