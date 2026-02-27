using apibanque.models;
using apibanque.services.implementations;
using apibanque.services.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace apibanque.controllers
{
    public class ClientController
    {
        private readonly iclientservice _service;

        public ClientController(iclientservice service)
        {
            _service = service;
        }

        public void Handle(HttpListenerContext context)
        {
            if (context.Request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(context.Request.InputStream))
                {
                    string body = reader.ReadToEnd();
                    Client client = JsonConvert.DeserializeObject<Client>(body);

                    _service.CreateClient(client);

                    string response = JsonConvert.SerializeObject("Client créé avec succès");

                    byte[] buffer = Encoding.UTF8.GetBytes(response);
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.OutputStream.Close();
                }
            }
        }
    }
}
