using System;
using System.Linq;
using System.Reflection;

/*
 Создать на языке C# пользовательский атрибут с именем ExportClass, применимый только к классам, и реализовать консольную программу, которая: 
- принимает в параметре командной строки путь к сборке .NET (EXE- или DLL-файлу);
- загружает указанную сборку в память;
- выводит на экран полные имена всех public-типов данных этой сборки, помеченные атрибутом ExportClass.
*/

namespace SPP8
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\User\\source\\repos\\mpp_lab_8\\mpp_lab_8\\mpp_lab_8.dll";
            Assembly assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes().Where(t => t.IsPublic && t.IsDefined(typeof(ExportClass), false));//фолс не будет дочерних
            Console.WriteLine("ExportClass:");
            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]//ограничения для класса
    public class ExportClass : Attribute { }//наследуем чтобы экспорт юзать как атрибут

    [ExportClass]
    public class PublicClass { }
    [ExportClass]
    internal class InternalClass { }
}