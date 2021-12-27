using System;
using System.Collections.Concurrent;
using System.IO;
using System.Timers;

/*
Создать класс LogBuffer, который:
- представляет собой журнал строковых сообщений;
- предоставляет метод public void Add(string item);
- буферизирует добавляемые одиночные сообщения и записывает их пачками в конец текстового файла на диске;
- периодически выполняет запись накопленных сообщений, когда их количество достигает заданного предела;
- периодически выполняет запись накопленных сообщений по истечение заданного интервала времени (вне зависимости от наполнения буфера);
- выполняет запись накопленных сообщений асинхронно с добавлением сообщений в буфер;
*/

namespace SixthTask
{
    class LogBuffer
    {
        private static ConcurrentQueue<string> Messages = new ConcurrentQueue<string>();
        private readonly StreamWriter _streamWriter;

        private const int Capacity = 30;
        private const int Limit = 1;
        private static readonly Timer timer = new Timer(Limit);

        public LogBuffer(string filePath = "C:\\Users\\User\\source\\repos\\mpp_lab_6\\mpp_lab_6\\logbuffere.txt")
        {
            

            _streamWriter = new StreamWriter(filePath, true);
            timer.Elapsed += CheckTime;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Add(string item)
        {
            Messages.Enqueue(item);
            CheckCapacity();
        }

        private void CheckCapacity()
        {
            if (Messages.Count < Capacity)
            {
                return;
            }

            while (!Messages.IsEmpty)
            {
                Messages.TryDequeue(out string message);
                if (message != null)
                {
                    _streamWriter.WriteLineAsync(message);
                }
            }
        }

        private void CheckTime(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(true);
            while (!Messages.IsEmpty)
            {
                Messages.TryDequeue(out var message);
                if (message != null)
                {
                    _streamWriter.WriteLineAsync(message);
                }
            }
        }

        public void Close()
        {
            _streamWriter.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LogBuffer logBuffer = new LogBuffer();
            for (var i = 0; i < 100; i++)
            {
                logBuffer.Add(i.ToString());
            }
            logBuffer.Close();
        }
    }
}
