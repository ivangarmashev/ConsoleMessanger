using System;
using Newtonsoft.Json;

namespace ConsoleMessanger
{
    class Program
    {
        static void Main(string[] args)
        {
            var msg = new Message();
            Console.WriteLine("Start..");
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserilizedMessage = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserilizedMessage);
            // Console.WriteLine(msg.ToString());
        }
    }
}