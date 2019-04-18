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
        StatedButtonControl[,] playerField;
        ShipCollection ships;
        private static int shuCounter = 0;
        private static int selectedLength = 0;

        static GameWindow()
        {
        }

        public GameWindow()
        {
            InitializeComponent();
            playerField = FieldDrower.CreateEmptyField(this);
            AddButtons(playerField);
            ships = new ShipCollection();
        }
      
        public void ButtonSquare_Click(object sender, RoutedEventArgs e)
        {


        }

        private void AddButtons(StatedButtonControl[,] buttons)
        {
            foreach (StatedButtonControl btn in buttons)
            {
                gameFieldGrid.Children.Add(btn);
            }
        }

        public void TurnButton_Click(object sender, RoutedEventArgs e)
        {
            shuCounter++;
            if (shuCounter == 10)
            {
                turnButton.RaiseEvent(new RoutedEventArgs(TurnButton.SchukinEvent, sender));
                shuCounter = 0;
            }
        }

        private void Ship_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            selectedLength = (int) btn.Tag;
        }
    }
}
