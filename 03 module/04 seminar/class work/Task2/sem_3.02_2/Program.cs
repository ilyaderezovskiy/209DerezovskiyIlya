using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        public class Passenger
        {
            protected int name;
            protected int lastname;

            protected int age;

            public bool IsOld { get; }

            public Passenger(int name, int lastname, int age)
            {
                this.name = name;
                this.lastname = lastname;

                this.age = age;

                if (this.age >= 65)
                    IsOld = true;
            }

            public override string ToString()
            {
                return $"Class: Passenger; Name: {lastname} {name}; Age: {age}";
            }
        }

        public class PassengerWithChildren : Passenger
        {
            public bool IsNewBorn { get; }
            public int NumberOfChildren { get; }

            public PassengerWithChildren(bool isNewBorn, int numberOfChildren, int name, int lastname, int age) : base(name, lastname, age)
            {
                NumberOfChildren = numberOfChildren;
                IsNewBorn = isNewBorn;
            }

            public override string ToString()
            {
                return $"Class: Passenger with children; Name: {lastname} {name}; Age: {age}; Number of children: {NumberOfChildren}";
            }
        }

        public class PassengerQueue
        {
            Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
            Queue<Passenger> priorityQueue = new Queue<Passenger>();

            public void AddToQueue(Passenger newPassenger)
            {
                if (newPassenger.IsOld || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn)
                    priorityQueue.Enqueue(newPassenger);

                else ordinaryQueue.Enqueue(newPassenger);
            }

            public void StartServingQueue()
            {
                while (priorityQueue.Count > 3)
                {
                    Console.WriteLine($"\nBoarding gate:\n{priorityQueue.Peek()}");
                    priorityQueue.Dequeue();

                    if (ordinaryQueue.Count != 0)
                    {
                        Console.WriteLine($"\nBoarding gate:\n{ordinaryQueue.Peek()}");
                        ordinaryQueue.Dequeue();
                    }
                }

                while (priorityQueue.Count != 0)
                {
                    Console.WriteLine($"\nBoarding gate:\n{priorityQueue.Peek()}");
                    priorityQueue.Dequeue();
                }

                while (ordinaryQueue.Count != 0)
                {
                    Console.WriteLine($"\nBoarding gate:\n{ordinaryQueue.Peek()}");
                    ordinaryQueue.Dequeue();
                }
            }
        }

        class MainClass
        {
            public static void Main()
            {
                Random random = new Random();
                PassengerQueue queue = new PassengerQueue();

                for (int i = 0; i < random.Next(0, 200); i++)
                {
                    Passenger passenger;

                    if (Convert.ToBoolean(random.Next(0, 2)))
                        passenger = new PassengerWithChildren(Convert.ToBoolean(random.Next(0, 2)), random.Next(1, 41),
                            random.Next(), random.Next(), random.Next(18, 120));

                    else passenger = new Passenger(random.Next(), random.Next(), random.Next(18, 120));

                    queue.AddToQueue(passenger);
                }

                queue.StartServingQueue();
            }
        }
    }
}