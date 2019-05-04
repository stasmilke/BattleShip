using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Controls.Primitives;


namespace BattleShip
{
    public class StatedButton : ButtonBase
    {
        public static readonly DependencyProperty StateProperty;
        public static readonly DependencyProperty InSettingProperty;

        public Ship LinkedShip { get; set; }

        static StatedButton()
        {
            StateProperty = DependencyProperty.Register("ButtonState", typeof(State), typeof(StatedButton), new UIPropertyMetadata(State.Unselected));
            InSettingProperty = DependencyProperty.Register("InSetting", typeof(bool), typeof(StatedButton), new UIPropertyMetadata(false));
        }

        public bool InSetting
        {
            get { return (bool)GetValue(InSettingProperty); }
            set { SetValue(InSettingProperty, value); }
        }

        public State ButtonState
        {
            get { return (State)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        public enum State
        {
            Unselected,
            SetShip,
            Ship,
            HidenShip,
            Selected,
            Missed,
            Killed,
            Locked
        }
    }
}
