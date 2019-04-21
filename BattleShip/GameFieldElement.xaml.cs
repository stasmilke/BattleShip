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
        public StatedButtonControl[,] PlayerField { get; private set; }
        public GameField FieldSetter { get; private set; }
        public static readonly DependencyProperty InSettingProperty;
        public static readonly DependencyProperty ComputerProperty;
        static GameFieldElement()
        {
            InSettingProperty = DependencyProperty.Register("InSetting", typeof(bool), typeof(GameFieldElement), new UIPropertyMetadata(false));
            ComputerProperty = DependencyProperty.Register("Computer", typeof(bool), typeof(GameFieldElement), new UIPropertyMetadata(false));
        }

        public bool InSetting
        {
            get { return (bool)GetValue(InSettingProperty); }
            set { SetValue(InSettingProperty, value); }
        }

        public bool Computer
        {
            get { return (bool)GetValue(ComputerProperty); }
            set { SetValue(ComputerProperty, value); }
        }

        public GameFieldElement()
        {
            InitializeComponent();
            PlayerField = CreateEmptyField();
            AddButtons(PlayerField);
            FieldSetter = new GameField();
        }

        public StatedButtonControl[,] CreateEmptyField()
        {
            StatedButtonControl[,] buttons = new StatedButtonControl[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new StatedButtonControl(this);
                    buttons[i, j].Tag = new Point(i, j);
                }
            }
            return buttons;
        }

        private void AddButtons(StatedButtonControl[,] buttons)
        {
            foreach (StatedButtonControl btn in buttons)
            {
                fieldGrid.Children.Add(btn);
            }
        }
    }
}
