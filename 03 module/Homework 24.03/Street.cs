using System;

namespace library
{
    public class Street
    {
        private string name
        { get; set; }

        private int[] houses
        { get; set; }

        public Street(string name, int[] houses)
        {
            this.name = name;
            this.houses = houses;
        }

        public static int operator ~(Street street)
        {
            return street.houses.Length;
        }

        public static bool operator !(Street street)
        {
            for (int i = 0; i < street.houses.Length; i++)
            {
                int[] housesCopy = (int[])street.houses.Clone();
                while (housesCopy[i] > 0)
                {
                    if (housesCopy[i] % 10 == 7)
                    {
                        return true;
                    }
                    else
                    {
                        housesCopy[i] /= 10;
                    }
                }
                if (i == housesCopy.Length - 1)
                {
                    break;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{name} {String.Join(" ", houses)}";
        }
    }
}
