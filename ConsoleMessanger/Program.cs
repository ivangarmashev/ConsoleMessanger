using System;
using Newtonsoft.Json;

namespace ConsoleMessanger
{
    class Program
    {
        private static int messageId;
        private static string username;
        private static MessangerClientAPI Api = new MessangerClientAPI();

        private static void GetNewMessages()
        {
            Message message = Api.GetMessage(messageId);
            while (message != null){}
            {
                Console.WriteLine(message);
                messageId++;
                message = Api.GetMessage(messageId);
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
                GetNewMessages();
                messageText = Console.ReadLine();
                if (messageText.Length > 1)
                {
                    Message sendMessage = new Message(username, messageText, DateTime.Now);
                    Api.SendMessage(sendMessage);
                }
            }
        }
    }
}