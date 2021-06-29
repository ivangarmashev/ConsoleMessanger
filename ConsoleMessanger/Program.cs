using System;

namespace ConsoleMessanger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("User1", "Text1", DateTime.Today);
            Console.WriteLine("Start..");
            Console.WriteLine(msg.ToString());
        }
    }
}