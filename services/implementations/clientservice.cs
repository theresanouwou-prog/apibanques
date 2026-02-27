using apibanque.models;
using apibanque.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.services.implementations
{
    public class clientservice
    {
        private readonly iclientrepository _repository;

        public clientservice(iclientrepository repository)
        {
            _repository = repository;
        }
        public void CreateClient(Client client)
        {
            if (string.IsNullOrEmpty(client.nom))
                throw new Exception("nom obligatoire");
            _repository.Add(client);
        }
        public List<Client> GetClient()
        {
            return _repository.GetAll();
        }

            
    }
}
