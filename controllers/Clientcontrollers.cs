using apibanque.models;
using apibanque.services.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.controllers
{
    public class Clientcontrollers
    {
        private readonly iclientservice _service;

        public Clientcontrollers (iclientservice service)
        {
            _service = service;
        }

        public object JsonConvert { get; private set; }

        public void handle(HttpListenerContext context)
        {
            if (context.Request.HttpMethod == "POST")
            {
                using(StreamReader reader = new StreamReader(context.Request.InputStream))
                {
                    string body = reader.ReadToEnd();
                    Client client = JsonConvert.DeserializeObject<Client>(body);
                    _service.CreateClient(client);

                    string response = JsonConvert.SerializeObject("client cree avec sucess");

                    byte[] buffer = Encoding.UTF8.GetBytes(response);
                    context.Response.OutputStream.Write(buffer, 0, buffer.Lenght);
                }
            }
            
        }
    }
}
