using System;
using System.Drawing;

class Robot
{
    // класс для представления робота
    public int x, y; // положение робота на плоскости 

    public void Right() { x++; }      // направо
    public void Left() { x--; }      // налево
    public void Forward() { y++; }  // вперед
    public void Backward() { y--; }  // назад

    public string Position()
    {  // сообщить координаты
        return String.Format("The Robot position: x={0}, y={1}", x, y);
    }
}

delegate void Steps(); // делегат-тип

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размеры поля - целые положительные числа (Например: 5 6, где 5 - количество клеток по горизонтали, а 6 - по вертикали):");
        string str = Console.ReadLine();
        int w;
        int h;
        bool success_w = int.TryParse(str.Split(' ')[0], out w) && w > -1;
        bool success_h = int.TryParse(str.Split(' ')[1], out h) && h > -1;
        if (success_w == false || success_h == false)
        {
            Console.WriteLine("Некорректный формат ввода!");
            Environment.Exit(0);
        }
        string[,] map = new string[w, h];   // создание поля

        Robot rob = new Robot();    // конкретный робот
        Console.WriteLine(rob.Position());  // начальная позиция
        Console.WriteLine("Введите программу для Робота:");
        string path = Console.ReadLine();   // ввод пути

        Steps delR = new Steps(rob.Right);      // направо
        Steps delL = new Steps(rob.Left);       // налево
        Steps delF = new Steps(rob.Forward);    // вперед
        Steps delB = new Steps(rob.Backward);   // назад

        for (int k = 0; k < path.Length; k++)
        {
            switch (path[k])
            {
                case 'R':
                    delR();      // направо
                    break;
                case 'L':
                    delL();      // налево
                    break;
                case 'F':
                    delF();      // вперед
                    break;
                case 'B':
                    delB();      // назад
                    break;
                default:
                    Console.WriteLine($"Incorrect command {path[k]}");
                    break;
            }
            int x = rob.x;
            int y = rob.y;
            try
            {
                if (k < path.Length - 1)
                {
                    map[w - 1 - y, x] = "+";
                }
                else
                    map[w - 1 - y, x] = "*";
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы поля!");
                Environment.Exit(0);
            }
        }

        map[w - 1, 0] = "+";
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                if (map[i, j] == null)
                    map[i, j] = ".";
                else if (map[i, j] == "*")
                    Console.ForegroundColor = ConsoleColor.Red;
                else 
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(map[i, j]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine(rob.Position());     // сообщить координаты
    }
}
