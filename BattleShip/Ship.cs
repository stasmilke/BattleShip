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
    public class Ship
    {
        public bool IsVertical { set; get; }
        public StatedButton[] Position { get; set; }
        public int Left { get; private set; }
        public Ship(int length)
        {
            ShipLength = length;
            Left = length;
            IsKilled = false;
            Position = new StatedButton[length];
        }

        public void Decrement()
        {
            Left--;
            if (Left == 0)
            {
                IsKilled = true;
            }
        }
        public int ShipLength { get; }
        public bool IsKilled { get; private set; }
    }
}
