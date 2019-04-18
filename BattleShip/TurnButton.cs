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
using System.Windows.Controls.Primitives;

namespace BattleShip
{
    public class TurnButton : CheckBox
    {
        public static readonly RoutedEvent SchukinEvent = EventManager.RegisterRoutedEvent(
            "Schukin", RoutingStrategy.Tunnel, typeof(RoutedEventHandler), typeof(TurnButton));

        public event RoutedEventHandler Schukin
        {
            add { AddHandler(SchukinEvent, value); }
            remove { RemoveHandler(SchukinEvent, value); }
        }
    }
}
