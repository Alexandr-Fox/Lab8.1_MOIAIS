using System;
using System.Collections.Generic;

namespace Lab8._1_MOIAIS_v8
{
    interface Int<T>
    {
        public LinkedList<T> List { get; set; }
        public void append(LinkedList<T> l1);
        public void appstart( LinkedList<T> l2);
        public void del_last_e(LinkedList<T> l2);
        public LinkedList<T> reversed();
        public int sum(); 
        public void delete( LinkedListNode<T> node);
        public LinkedListNode<T> find_last(string value);
        public void swap_pairs();
    }
    class Class1 : Int<string>
    {
        public LinkedList<string> List { get; set ; }
        public Class1() => List = new LinkedList<string>();
        public Class1(LinkedList<string> l) => List = l;
        public void append( LinkedList<string> l1)
        {
            foreach(string t in l1)
                List.AddLast(t);
        }
        public void appstart(LinkedList<string> l2)
        {
            LinkedList<string> l = new();
            foreach (string t in l2)
            {
                l.AddFirst(t);
            }
            foreach (string t in l)
            {
                List.AddFirst(t);
            }
        }
        public void del_last_e(LinkedList<string> l2)
        {
            while (List.Find(l2.Last.Value) != null)
            {
                List.Remove(List.Find(l2.Last.Value));
            }
        }
        public void delete(LinkedListNode<string> node)
        {
            if (List.Contains(node.Value))
            {
                List.Remove(List.Find(node.Value));
                Console.WriteLine("Элемент удален");
            }
            else Console.WriteLine("Нет такого элемента");
        }
        public LinkedListNode<string> find_last(string value)=> List.FindLast(value);
        public LinkedList<string> reversed()
        {
            LinkedList<string> l1 = new();
            foreach (string t in List)
            {
                l1.AddFirst(t);
            }
            return l1;
        }
        public int sum()
        {
            int sum = 0;
            int j;
            foreach (string t in List)
            {
                if (int.TryParse(t, out j))
                {
                    sum += Convert.ToInt32(t);
                }
            }
            return sum;
        }
        public void swap_pairs()
        {
            LinkedListNode<string> lN = List.First;
            for (int i = 0; i < List.Count -1; i+=2)
            {
                string v = lN.Value;
                LinkedListNode<string> lN1 = lN.Next;
                lN.Value = lN1.Value;
                lN1.Value = v;
                lN = lN1.Next;

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new();
            while (true)
            {
                Console.WriteLine("1) Создать второй список и добавить его в конец");
                Console.WriteLine("2) Создать развернутую копию списка");
                Console.WriteLine("3) Сумма элементов списка");
                Console.WriteLine("4) Удаление заданного элемента");
                Console.WriteLine("5) Поиск элемента по значению с конца");
                Console.WriteLine("6) Поменять соседние пары местами");
                Console.WriteLine("7) Создать второй список и добавить  его в начало");
                Console.WriteLine("8) Добавить элемент");
                Console.WriteLine("9) Вывод на экран");
                Console.WriteLine("10) Создать второй список и удалить из первого последний элемент второго");
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
                            LinkedList<string> l = new LinkedList<string>();
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                                l.AddLast(Console.ReadLine());
                            c1.append(l);
                            break;
                        }
                    case "2":
                        {
                            c1.List = c1.reversed();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(c1.sum());
                            break;
                        }
                    case "4":
                        {
                            LinkedListNode<string> l = new(Console.ReadLine());
                            c1.delete(l);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine(c1.find_last(Console.ReadLine()));
                            break;
                        }
                    case "6":
                        {
                            c1.swap_pairs();
                            break;
                        }
                    case "7":
                        {
                            LinkedList<string> l = new LinkedList<string>();
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                                l.AddLast(Console.ReadLine());
                            c1.appstart(l);
                            break;
                        }
                    case "8":
                        {
                            c1.List.AddLast(Console.ReadLine());
                            break;
                        }
                    case "9":
                        {
                            foreach (string s in c1.List)
                                Console.WriteLine(s);
                            break;
                        }
                    case "10":
                        {
                            LinkedList<string> l = new LinkedList<string>();
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                                l.AddLast(Console.ReadLine());
                            c1.del_last_e(l);
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
