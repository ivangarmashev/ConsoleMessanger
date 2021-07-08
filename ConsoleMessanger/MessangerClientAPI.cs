using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleMessanger
{
    class MessangerClientAPI
    {
        public void TestNewtonsoftJson()
        {
            Message message = new Message();
            string output = JsonConvert.SerializeObject(message);
            // Console.WriteLine(output);
            Message deserializedMessage = JsonConvert.DeserializeObject<Message>(output);
            // Console.WriteLine(deserializedMessage);
        }

        public Message GetMessage(int messageId)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger/" + messageId);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            // Console.WriteLine(status);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            // Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            if ((status == "OK") && (responseFromServer != "Not found"))
            {
                Message deserializedMessage = JsonConvert.DeserializeObject<Message>(responseFromServer);
                Console.WriteLine(deserializedMessage);
                // Console.WriteLine("deseralizedmsg, then return");
                return deserializedMessage;
            }

            // Console.WriteLine("return null");
            return null;
        }

        public bool SendMessage(Message message)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger/");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(message);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responsеFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return true;
        }
    }
}




