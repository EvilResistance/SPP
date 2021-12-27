using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

/*Реализовать консольную программу на языке C#, которая: 
- принимает в параметре командной строки путь к сборке .NET (EXE- или DLL-файлу);
- загружает указанную сборку в память;
- выводит на экран полные имена всех public-типов данных этой сборки,
упорядоченные по пространству имен (namespace) и по имени.
*/

namespace SPPLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(Console.ReadLine());

            List<Type> types = assembly.GetTypes().ToList();
            types = types.Where(type => type.IsPublic).OrderBy(type => type.Namespace).ThenBy(type => type.Name).ToList();
            foreach (Type publicTypes in types)
                Console.WriteLine(publicTypes.ToString());
            Console.ReadLine();
        }
    }
}
