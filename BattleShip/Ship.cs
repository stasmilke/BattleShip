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
        public delegate void ShipStateHandler(Ship injShip, Point injPoint);

        public event ShipStateHandler Killed;
        public event ShipStateHandler Injured;
        public event ShipStateHandler Missed;

        public StatedButton[] Position { get; set; }
        private int left;
        public Ship(int length)
        {
            ShipLength = length;
            left = length;
            IsKilled = false;
            Position = new StatedButton[length];
        }

        public int ShipLength { get; }
        public bool IsKilled { get; }

        public void CheckShot(Point shotPoint)
        {
            foreach (StatedButton btn in Position)
            {
                if (btn.Tag.Equals(shotPoint))
                {
                    left--;
                    if (left == 0)
                    {
                        Killed(this, (Point) btn.Tag);
                    } 
                    else
                    {
                        Injured(this, (Point) btn.Tag);
                    }
                }
            }
            Missed(this, shotPoint);
        }
    }
}
