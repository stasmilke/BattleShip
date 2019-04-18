using System.Collections.Generic;

namespace BattleShip
{
    class ShipCollection : List<Ship>
    {
        public delegate void CollectionHandler();

        public event CollectionHandler Changed;

        public ShipCollection()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4 - j; i++)
                {
                    this.Add(new Ship(j + 1));
                }
            }
        }

        public Ship GetShip(int length)
        {
            Ship ship = Find(x => x.ShipLength == length);
            Remove(ship);
            Changed();
            return ship;
        }

        public void ReturnShip(int length)
        {
            Add(new Ship(length));
            Changed();
        }

        public int[] GetNumbers()
        {
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = FindAll(x => x.ShipLength == i + 1).Count;
            }
            return numbers;
        }
    }
}
