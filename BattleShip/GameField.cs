using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class GameField
    {
        public bool isSetting;

        public GameField(bool isAuto)
        {
            isSetting = !isAuto;
        }


    }
}
