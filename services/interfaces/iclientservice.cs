using apibanque.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.services.interfaces
{
    public interface iclientservice
    {
        void CreateClient(Client client);
        List<Client> GetClient();
    }
}
