using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.repository.interfaces
{
    public interface ITransactionService
    {
        void Depot(int compteId, decimal montant);
        void Retrait(int compteId, decimal montant);
        void Virement(int sourceId, int destinationId, decimal montant);
    }
}
