using System;
using Newtonsoft.Json;

namespace ConsoleMessanger
{
    class Program
    {
        private static int messageId;
        private static string username;
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static void GetNewMessages()
        {
            Message message = API.GetMessage(messageId);
            // Console.WriteLine(message);
            
            while (message != null)
            {
                // Console.WriteLine(message);
                messageId++;
                // Console.WriteLine(messageId);
                message = API.GetMessage(messageId);
                // Console.WriteLine("end of getMessage");
            }
            
        }
        static void Main(string[] args)
        {
            // var msg = new Message();
            // Console.WriteLine("Start..");
            // string output = JsonConvert.SerializeObject(msg);
            // Console.WriteLine(output);
            // Message deserializedMessage = JsonConvert.DeserializeObject<Message>(output);
            // Console.WriteLine(deserializedMessage);
            messageId = 0;
            Console.WriteLine("Введите ваше имя:");
            username = Console.ReadLine();
            string messageText = "";
            while (messageText != "exit")
            {
                // Console.WriteLine("цикл while");
                GetNewMessages();
                Console.WriteLine("Введите сообщение:");
                messageText = Console.ReadLine();
                if (messageText.Length > 1)
                {
                    
                    // Console.WriteLine("цикл if");
                    Message sendMessage = new Message(username, messageText, DateTime.Now);
                    API.SendMessage(sendMessage);
                    messageText = "";
                }
            }
        }
    }
}