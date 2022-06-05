using System;
using System.Collections.Generic;
using System.IO;

namespace Lab8._1_MOIAIS_v8
{
    interface Int<T>
    {
        public LinkedList<T> copy(LinkedList<T> l);
        public LinkedList<T> sublist_copy( int from, int to);
        public LinkedList<T> repeat(int count);
        public int sum();
        public LinkedList<T> reversed();
        public int get_length();
        public void delete_e(string s);
    }
    class Class1 : Int<string>
    {
        public LinkedList<string> List { get; set ; }
        public Class1()
        {
            List = new LinkedList<string>();
        }

        public Class1(LinkedList<string> l)
        {
            List = l;
        }

        public void delete_e( string l1)
        {
            foreach(string t in List)
                if (t.Length > l1.Length)
                    List.Remove(t);
        }
        public LinkedList<string> repeat( int c)
        {
            var l1 = new LinkedList<string>();
            for (int i = 0; i < c; i++)
            {
                foreach (string t in List)
                    l1.AddLast(t);
            }
            return l1;
        }
        public LinkedList<string> copy(LinkedList<string> l) 
        {
            return new LinkedList<string>(l);
        }
        public int get_length()
        {
            // return l.Count;
            int c = 0;
            LinkedListNode<string> node = List.First;
            while (node != null)
            {
                c++;
                node = node.Next;
            }
            return c;
        }
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
        public LinkedList<string> sublist_copy( int from, int to)
        {
            LinkedListNode<string> lN = List.First;
            LinkedList<string> list = new();
            for(int i = 0; i < from; i++)
            {
                lN = lN.Next;
            }
            for (int i = from; i < to; i++)
            {
                list.AddLast(lN.Value);
                lN = lN.Next;
            }
            return list;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new();
            while (true)
            {
                Console.WriteLine("2) Создать развернутую копию списка");
                Console.WriteLine("3) Сумма элементов списка");
                Console.WriteLine("8) Добавить элемент");
                Console.WriteLine("9) Вывод на экран");
                Console.WriteLine("0) Выход");
                Console.Write("Выбирите действие: ");
                var d = Console.ReadLine();
                Console.Clear();
                switch (d)
                {
                    case "0":
                        {
                            Environment.Exit(0);// выход
                            break;
                        }
                    case "1":
                        {
                            c1.delete_e( Console.ReadLine());// удаление из списка элементов больших по длинне чем введенная строка
                            break;
                        }
                    case "2":
                        {
                            c1.List = c1.reversed();// создает развернутую копию списка и записывает ее вместо того списка который был
                            /*
                             * данный цикл выведет развернутую копию списка на экран (закоментируй строку выше и раскоментируй цикл)
                            foreach(string s in c1.reversed())
                                Console.WriteLine(s);
                            */
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(c1.sum());//выводит сумму чисел в списке(если конечно среди строк найдутся числа)
                            break;
                        }
                    case "4":
                        {
                            c1.List = c1.repeat( Convert.ToInt32(Console.ReadLine()));// создает повторенную n раз копию списка и перезаписывает его
                            /*
                             * данный цикл выведет повторенную n раз копию списка на экран (закоментируй строку выше и раскоментируй цикл)
                            foreach(string s in c1.reversed())
                                Console.WriteLine(s);
                            */
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine(c1.get_length());// выводит на экран размер списка
                            break;
                        }
                    case "6":
                        {
                            Random random = new();
                            int v = random.Next(c1.get_length());
                            c1.List = c1.sublist_copy( v, random.Next(v+1, c1.get_length()));//Создать список из элементов с индексами [from, to] и перезаписать его
                            /*
                             * данный цикл выведетсписок из элементов с индексами [from, to] на экран (закоментируй строку выше и раскоментируй цикл)
                            foreach(string s in c1.sublist_copy( v, random.Next(v+1, c1.get_length())))
                                Console.WriteLine(s);
                            */
                            break;
                        }
                    case "7":
                        {
                            LinkedList<string> l = new LinkedList<string>();
                            int count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                                l.AddLast(Console.ReadLine());
                            c1.List = c1.copy(l);// Создаст копию только что введенного списка и перезапишет ей текущий
                            /*
                             * данный цикл выведет перезаписаный список на экран (ничего не надо коментировать, просто расскаоментируй цикл)
                            foreach(string s in c1.List)
                                Console.WriteLine(s);
                            */
                            break;
                        }
                    case "8":
                        {
                            c1.List.AddLast(Console.ReadLine());// добавляет элемент в список
                            break;
                        }
                    case "9":
                        {
                            foreach(string s in c1.List) // выведет список на экран
                                Console.WriteLine(s);
                            break;
                        }
                    case "10":
                        {
                            // добавление данных из файла
                            string path = Console.ReadLine();
                            if (File.Exists(path))
                            {
                                StreamReader reader = File.OpenText(path);
                                string s;
                                while ((s = reader.ReadLine()) != null)
                                    c1.List.AddLast(s);
                                Console.WriteLine("Данные из файла добавлены!");
                            }
                            else
                                Console.WriteLine("Нет такого файла!");
                            break;
                        }
                }
                Console.WriteLine("Для возврата в меню нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}
