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
    class Ship
    {
        public delegate void ShipStateHandler(Ship injShip, Point injPoint);

        public event ShipStateHandler Killed;
        public event ShipStateHandler Injured;
        public event ShipStateHandler Missed;

        private Point[] arrayLinkedPoints;
        private int left;
        public Ship(int length)
        {
            ShipLength = length;
            left = length;
            IsKilled = false;
        }

        public int ShipLength { get; }
        public bool IsKilled { get; }

        public void SetPostion(Point[] points)
        {
            arrayLinkedPoints = points;
        }

        public void CheckShot(Point shotPoint)
        {
            foreach (Point point in arrayLinkedPoints)
            {
                if (point.Equals(shotPoint))
                {
                    left--;
                    if (left == 0)
                    {
                        Killed(this, point);
                    } 
                    else
                    {
                        Injured(this, point);
                    }
                }
            }
            Missed(this, shotPoint);
        }
    }
}
