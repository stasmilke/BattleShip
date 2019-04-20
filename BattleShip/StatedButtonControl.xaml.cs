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
using System.Windows.Controls.Primitives;



namespace BattleShip
{
    /// <summary>
    /// Логика взаимодействия для StatedButtonControl.xaml
    /// </summary>
    public partial class StatedButtonControl : UserControl
    {
        public GameFieldElement ThisField { get; private set; }

        public StatedButtonControl(GameFieldElement field)
        {
            InitializeComponent();
            ThisField = field;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ThisField.IsSetting && button.ButtonState == StatedButton.State.Unselected)
            {
                ThisField.FieldSetter.SetShipState(this);
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ThisField.IsSetting && button.ButtonState == StatedButton.State.SetShip)
            {
                ThisField.FieldSetter.UnsetShipState();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ThisField.IsSetting)
            {
                if (button.ButtonState == StatedButton.State.Ship)
                {
                    ThisField.FieldSetter.UnsetShipFromField(button.LinkedShip, this);
                }
                else
                {
                    ThisField.FieldSetter.SetShipOnField(ThisField);
                }
            }
        }
    }
}
