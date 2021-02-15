using System;
using System.Collections.Generic;

namespace Task
{
    class Node
    {
        public Node(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node Next { get; set; }
        public override string ToString()
        {
            return $"{Data}"; // !!!
            //return $"{Data} - {Next}"; // !!!
        }
    }

    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void Add(int value)
        {
            Node node = new Node(value);
            if (Head == null)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;
            Count++;
        }

        public void Print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public void Clear() 
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(int data) 
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == data)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void AppendFirst(int data)
        {
            Node node = new Node(data);
            node.Next = Head;
            Head = node;
            if (Count == 0)
                Tail = Head;
            Count++;
        }

        public Node Max()
        {
            Node current = Head;
            Node max = null;
            while (current != null)
            {
                if (max == null)
                    max = current;
                else if (max.Data < current.Data)
                    max = current;
                current = current.Next;
            }
            return max;
        }

        public bool Remove(int data)
        {
            Node current = Head;
            Node prev = null;

            while (current != null)
            {
                if (current.Data == data)
                {
                    if (prev != null)
                    {
                        prev.Next = current.Next;
                        if (current.Next == null)
                            Tail = prev;
                    }
                    else 
                    {
                        Head = Head.Next;
                    }
                    if (Head == null)
                        Tail = null;
                    Count--;
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }

        public void Reverse()
        {
            Node curr = Head,
                 next = null,
                 prev = null;
            Tail = Head;
            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            Head = prev;
        }
    }

    class Program
    {
        public static void Main()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add(1);
            linkedList.Remove(1);
            linkedList.Print();
        }
    }
}