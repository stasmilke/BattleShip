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
        private static string SAVE_TEXT = "Начать игру";
        private static string SETTING_TEXT = "Сохранить и начать игру";
        private static int shuCounter = 0;
        public static bool IsVertical { get; private set; } = false;
        public static int SelectedLength { get; private set; } = 0;
        public GameFieldElement ComputerField { get; private set; }

        public GameWindow()
        {
            InitializeComponent();
            gameFieldGrid.IsSetting = true;
            ShipCollection.Updated += UpdateAmount;
            ShipCollection.Empty += TurnSaveButton;
        }
      

        private void UpdateAmount(int[] amounts)
        {
            oneShip.Content = amounts[0];
            oneShip.IsEnabled = !(amounts[0] == 0);
            twoShip.Content = amounts[1];
            twoShip.IsEnabled = !(amounts[1] == 0);
            threeShip.Content = amounts[2];
            threeShip.IsEnabled = !(amounts[2] == 0);
            fourShip.Content = amounts[3];
            fourShip.IsEnabled = !(amounts[3] == 0);
            randomButton.IsEnabled = amounts[4] == 10;
        }

        private void TurnSaveButton(bool turn)
        {
            buttonSaveBegin.IsEnabled = turn;
            buttonSaveBegin.Content = turn ? SAVE_TEXT : SETTING_TEXT;
        }

        private void TurnButton_Click(object sender, RoutedEventArgs e)
        {
            SchukinCounter(sender);
            IsVertical = turnButton.IsChecked.Value;
        }

        private void Ship_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            SelectedLength = int.Parse((string)btn.Tag);
        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            gameFieldGrid.FieldSetter.SetRandomShips(gameFieldGrid);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            SchukinCounter(sender);
            if (turnButton.IsChecked.Value)
            {
                turnButton.RaiseEvent(new RoutedEventArgs(CheckBox.CheckedEvent));
                turnButton.IsChecked = false;
            }
            else
            {
                turnButton.RaiseEvent(new RoutedEventArgs(CheckBox.UncheckedEvent));
                turnButton.IsChecked = true;
            }
            IsVertical = turnButton.IsChecked.Value;
        }

        private void SchukinCounter(object sender)
        {
            shuCounter++;
            if (shuCounter == 10)
            {
                turnButton.RaiseEvent(new RoutedEventArgs(TurnButton.SchukinEvent, sender));
                shuCounter = 0;
            }
        }
    }
}
