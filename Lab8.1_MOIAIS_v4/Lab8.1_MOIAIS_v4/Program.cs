using System;
using System.Collections.Generic;

namespace Lab8._1_MOIAIS_v4
{
    interface INt<T>
    {
        public LinkedList<T> List { get; set; }
        public LinkedListNode<T> at_end( int index);
        public LinkedList<T> duplicate_copy();
        public LinkedList<T> sublist(int from, int to);
        public void delete_last();
        public void insert_instead(LinkedListNode<T> e, int index);
        public LinkedList<T> concat(LinkedList<T> l1);
        public LinkedList<T> duplicate_e(LinkedListNode<T> e);
        public void delete_all_e(LinkedListNode<T> e);
    }

    internal class Class1 : INt<string>
    {
        public LinkedList<string> List { get; set; }

        public Class1()
        {
            List = new LinkedList<string>();
        }

        public Class1(LinkedList<string> l)
        {
            List = l;
        }
        public LinkedListNode<string> at_end(int index)
        {
            if (index >= List.Count )
                return new LinkedListNode<string>(string.Empty);
            else
            {
                var node = List.Last;
                for (int i = 0; i < index; i++)
                    node = node.Previous;
                return node;
            }
        }
        public LinkedList<string> duplicate_copy()
        {
            LinkedList<string> copy = new LinkedList<string>();
            foreach (string s in List)
                copy.AddLast(s);
            foreach (string s in List)
                copy.AddLast(s);
            return copy;
        }
        public LinkedList<string> sublist( int from, int to)
        {
            var node = List.First;
            for(int i = 0; i < from; i++)
            {
                node = node.Next;
            }
            LinkedList<string> strings = new LinkedList<string>();
            for(int i = from; i <= to; i++)
            {
                strings.AddLast(node);
                node = node.Next;
            }
            return strings;
        }
        public void delete_last() => List.RemoveLast();
        public void insert_instead(LinkedListNode<string> e, int index)
        {
            var node = List.First;
            for (int i = 0; i < index; i++)
                node = node.Next;
            node.Value = e.Value;
        }
        public LinkedList<string> concat( LinkedList<string> l1)
        {
            var copy = new LinkedList<string>();
            foreach (string s in List)
                copy.AddLast(s);
            foreach (string s in l1)
                copy.AddLast(s);
            return copy;
        }
        public LinkedList<string> duplicate_e(LinkedListNode<string> e)
        {
            LinkedList<string> list = new();
            foreach(string s in List)
            {
                list.AddLast(s);
                if (s == e.Value)
                    list.AddLast(e.Value);
            }
            return list;
        }
        public void delete_all_e( LinkedListNode<string> e)
        {
            while (List.Contains(e.Value))
                List.Remove(e.Value);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new();
            while (true)
            {
                Console.WriteLine("1) Создать второй список и провести конкатацию двух списков");
                Console.WriteLine("2) Поиск элемента по индексу с конца");
                Console.WriteLine("3) Создать удвоенный список");
                Console.WriteLine("4) Создать список из элементов с индексами [from, to]");
                Console.WriteLine("5) Удалить последний элемент");
                Console.WriteLine("6) Заменить i-ый элемент");
                Console.WriteLine("7) Удвоить каждоее вхождение элемента E");
                Console.WriteLine("8) Удалить все элементы равные E");
                Console.WriteLine("9) Добавить элемент");
                Console.WriteLine("10) Вывод на экран");
                Console.WriteLine("0) Выход");
                Console.Write("Выбирите действие: ");
                var d = Console.ReadLine();
                Console.Clear();
                switch (d)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        {
                            LinkedList<string> l = new();
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                                l.AddLast(Console.ReadLine());
                            c1.List = c1.concat(l);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine( c1.at_end(Convert.ToInt32(Console.ReadLine())));
                            break;
                        }
                    case "3":
                        {
                            c1.List = c1.duplicate_copy();
                            break;
                        }
                    case "4":
                        {
                            int from = Convert.ToInt32(Console.ReadLine());
                            int to = Convert.ToInt32(Console.ReadLine());
                            c1.List = c1.sublist(from, to);
                            break;
                        }
                    case "5":
                        {
                            c1.delete_last();
                            break;
                        }
                    case "6":
                        {
                            LinkedListNode<string> node = new(Console.ReadLine());
                            var index = Convert.ToInt32(Console.ReadLine());
                            c1.insert_instead(node, index);
                            break;
                        }
                    case "7":
                        {
                            LinkedListNode<string> node = new(Console.ReadLine());
                            c1.List = c1.duplicate_e( node);
                            break;
                        }
                    case "8":
                        {
                            LinkedListNode<string> node = new(Console.ReadLine());
                            c1.delete_all_e(node);
                            break;
                        }
                    case "9":
                        {
                            c1.List.AddLast(Console.ReadLine());
                            break;
                        }
                    case "10":
                        {
                            foreach (string s in c1.List)
                                Console.WriteLine(s);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверное действие");
                            break;
                        }

                }
                Console.WriteLine("Для возврата в меню нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
