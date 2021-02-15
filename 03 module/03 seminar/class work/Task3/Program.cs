using System;

namespace sem_27._01_3
{
    class Account
    {
        // делегат void (string, int, int)
        public delegate void AccountHandler(string str, int sum, int accsum);
        // событие
        public event AccountHandler onSumChanged;
        public Account(int sum)
        {
            Sum = sum;
        }
        // сумма на счете
        public int Sum { get; private set; }
        // добавление средств на счет
        public void Put(int sum)
        {
            Sum += sum;
            onSumChanged?.Invoke("Put", sum, Sum);
        }
        // списание средств со счета
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                onSumChanged?.Invoke("Take", sum, Sum);
            }
            else
            {
                onSumChanged?.Invoke("Attempt to take (failed)", sum, Sum);
            }
        }
    }
    class Program
    {
        public static void SumChanged(string str, int sum, int accsum)
        {
            Console.WriteLine($"{str} - {sum} {accsum}");
        }
        static void Main(string[] args)
        {
            Account acc = new Account(100);
            acc.onSumChanged += SumChanged;
            acc.Put(20);    // добавляем на счет 20
            acc.Take(70);   // пытаемся снять со счета 70
            acc.Take(180);  // пытаемся снять со счета 180
            Console.Read();
        }
    }
}
