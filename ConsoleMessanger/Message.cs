using System;

namespace ConsoleMessanger
{
    [Serializable]
    public class Message
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }
        
        public Message(string userName, string messageText, DateTime timeStamp)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStamp = timeStamp;
        }
        public Message()
        {
            UserName = "Test name";
            MessageText = "Test text message";
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            var output = string.Format($"{UserName} <{TimeStamp}>: {MessageText}");
            return output;
        }
    }
}