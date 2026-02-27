using apibanque.controllers;
using apibanque.repository.implementations;
using apibanque.repository.interfaces;
using apibanque.services.implementations;
using apibanque.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace apibanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();

            Console.WriteLine("Serveur demarre..");

            iclientrepository repo = new clientrepository();
            iclientservice service = new clientservice(repo);
            ClientController controller = new ClientController(service);

            while(true)
            {
                var context = listener.GetContext();
                if (context.Request.Url.AbsolutePath == "/clients")
                {
                    controller.Handle(context);
                }
            }
               
        }
    }
}
