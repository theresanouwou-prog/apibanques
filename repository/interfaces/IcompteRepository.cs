using apibanque.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.repository.interfaces
{
    public interface ICompteRepository
    {
        void Add(Compte compte);
        Compte GetById(int id);
        void Update(Compte compte);
        List<Compte> GetAll();
    }
}
