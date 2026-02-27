using apibanque.repository.interfaces;
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
    public class TransactionController
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        public void HandleDepot(HttpListenerContext context)
        {
            using (StreamReader reader = new StreamReader(context.Request.InputStream))
            {
                dynamic data = JsonConvert.DeserializeObject(reader.ReadToEnd());

                _service.Depot((int)data.compteId, (decimal)data.montant);

                string response = JsonConvert.SerializeObject("Depot effectué");
                byte[] buffer = Encoding.UTF8.GetBytes(response);
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                context.Response.OutputStream.Close();
            }
        }
    }
}
