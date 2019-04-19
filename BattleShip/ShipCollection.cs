using System.Collections.Generic;

namespace BattleShip
{
    public class ShipCollection
    {
        private List<Ship> ships;

        public class NumbersLeft
        {
            public static void SetValue(int[] numbers)
            {
                First = numbers[0].ToString();
                Second = numbers[1].ToString();
                Third = numbers[2].ToString();
                Fourth = numbers[3].ToString();
            }
            public static string First { get; set; } = "4";
            public static string Second { get; set; } = "3";
            public static string Third { get; set; } = "2";
            public static string Fourth { get; set; } = "1";
        }

        public ShipCollection()
        {
            ships = new List<Ship>(10);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4 - j; i++)
                {
                    ships.Add(new Ship(j + 1));
                }
            }
        }

        public Ship GetShip(int length)
        {
            Ship ship = ships.Find(x => x.ShipLength == length);
            ships.Remove(ship);
            NumbersLeft.SetValue(GetNumbers());
            return ship;
        }

        public void ReturnShip(Ship ship)
        {
            ships.Add(new Ship(ship.ShipLength));
            NumbersLeft.SetValue(GetNumbers());
        }

        public int[] GetNumbers()
        {
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = ships.FindAll(x => x.ShipLength == i + 1).Count;
            }
            return numbers;
        }
    }
}
