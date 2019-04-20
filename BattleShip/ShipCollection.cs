using System.Collections.Generic;

namespace BattleShip
{
    public class ShipCollection
    {
        public delegate void UpdateAmount(int[] array);
        public static event UpdateAmount Updated;
        public delegate void ListIsEmpty(bool isEmpty);
        public static event ListIsEmpty Empty;

        private List<Ship> ships;
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
            Updated(GetNumbers());
            if (ships.Count == 0)
            {
                Empty(true);
            }
            return ship;
        }

        public void ReturnShip(Ship ship)
        {
            ships.Add(new Ship(ship.ShipLength));
            Updated(GetNumbers());
            if (ships.Count > 0)
            {
                Empty(false);
            }
        }

        public int[] GetNumbers()
        {
            int[] numbers = new int[5];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = ships.FindAll(x => x.ShipLength == i + 1).Count;
            }
            numbers[4] = ships.Count;
            return numbers;
        }
    }
}
