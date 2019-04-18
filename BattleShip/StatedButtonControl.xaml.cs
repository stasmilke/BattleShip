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
        private GameField thisField;

        public StatedButtonControl(GameField field)
        {
            InitializeComponent();
            thisField = field;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (thisField.isSetting)
            {

            }
            else
            {

            }
        }
    }
}
