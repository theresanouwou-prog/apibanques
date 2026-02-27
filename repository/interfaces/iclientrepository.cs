using apibanque.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.repository.interfaces
{
    public interface iclientrepository
    {
        void Add(Client client);
        List<Client> GetAll();
    }
}
