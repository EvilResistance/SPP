﻿/*
Задача 9.
Создать на языке C# обобщенный (generic-) класс DynamicList<T>, который:
- реализует динамический массив с помощью обычного массива T[];
- имеет свойство Count, показывающее количество элементов; 
- имеет свойство Items для доступа к элементам по индексу; 
- имеет методы Add, Remove, RemoveAt, Clear для соответственно добавления, удаления, удаления по индексу и удаления всех элементов;
- реализует интерфейс IEnumerable<T>.
Реализовать простейший пример использования класса DynamicList<T> на языке C#.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_lab_9
{
	class Program
	{
        static void Main(string[] args)
        {
            int i = 0;
            Type[] Types = { typeof(int),
                             typeof(string),
                             typeof(double) ,
                           };

            
            DynamicList<int> Dlist_int = new DynamicList<int>();

            Dlist_int.Add(0);
            Dlist_int.Add(1);
            Dlist_int.Add(2);
            Dlist_int.Add(3);
            Dlist_int.Add(4);



            foreach (int num in Dlist_int)
            {
                Console.WriteLine(num);
            }


            Console.WriteLine("\n");
            Console.WriteLine(Dlist_int[1]);
            Console.WriteLine(Dlist_int[0]);

            Dlist_int.Remove(1);
            Console.WriteLine(Dlist_int[1]);

            Dlist_int.RemoveAt(0);
            Console.WriteLine(Dlist_int[0]);

            Dlist_int.Clear();
            if (Dlist_int.Count == 0)
            {
                Console.WriteLine("array is empty");
            }
            else
            {
                Console.WriteLine(Dlist_int[0]);
            }

            foreach (int num in Dlist_int)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();


            ///////////////////////////////////////////////////

            DynamicList<string> Dlist_str = new DynamicList<string>();

            Dlist_str.Add("Line");
            Dlist_str.Add("Box");
            Dlist_str.Add("Cube");
            Dlist_str.Add("Circle");
            Dlist_str.Add("Nain");

            Console.WriteLine();

            foreach (String str in Dlist_str)
            {
                Console.WriteLine(str);
            }


            Console.WriteLine("\n");
            Console.WriteLine(Dlist_str[1]);
            Console.WriteLine(Dlist_str[0]);

            Dlist_str.Remove("Box");
            Console.WriteLine(Dlist_str[1]);

            Dlist_str.RemoveAt(0);
            Console.WriteLine(Dlist_str[0]);

            Dlist_str.Clear();
            if (Dlist_str.Count == 0)
            {
                Console.WriteLine("array is empty");
            }
            else
            {
                Console.WriteLine(Dlist_str[0]);
            }

            foreach (String str in Dlist_str)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
