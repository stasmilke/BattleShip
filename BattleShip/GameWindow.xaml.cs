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
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public ShipCollection ships;
        private static int shuCounter = 0;
        public static bool IsVertical { get; private set; } = false;
        public static int SelectedLength { get; private set; } = 0;
        public GameFieldElement ComputerField { get; private set; }
        public ShipCollection.NumbersLeft NumbersContext { set => grid1.DataContext = value; }

        public GameWindow()
        {
            InitializeComponent();
            gameFieldGrid.IsSetting = true;
            grid1.DataContext = new ShipCollection.NumbersLeft();
        }
      
        public void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {


        }

        private void TurnButton_Click(object sender, RoutedEventArgs e)
        {
            shuCounter++;
            if (shuCounter == 10)
            {
                turnButton.RaiseEvent(new RoutedEventArgs(TurnButton.SchukinEvent, sender));
                shuCounter = 0;
            }
            IsVertical = turnButton.IsChecked.Value;
        }

        private void Ship_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            SelectedLength = int.Parse((string)btn.Tag);
        }
    }
}
