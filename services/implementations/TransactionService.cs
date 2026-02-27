using apibanque.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.repository.implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly ICompteRepository _compteRepo;

        public TransactionService(ICompteRepository compteRepo)
        {
            _compteRepo = compteRepo;
        }

        public void Depot(int compteId, decimal montant)
        {
            var compte = _compteRepo.GetById(compteId);

            compte.Solde += montant;
            _compteRepo.Update(compte);
        }

        public void Retrait(int compteId, decimal montant)
        {
            var compte = _compteRepo.GetById(compteId);

            if (compte.Solde < montant)
                throw new Exception("Solde insuffisant");

            compte.Solde -= montant;
            _compteRepo.Update(compte);
        }

        public void Virement(int sourceId, int destinationId, decimal montant)
        {
            var source = _compteRepo.GetById(sourceId);
            var destination = _compteRepo.GetById(destinationId);

            if (source.Solde < montant)
                throw new Exception("Solde insuffisant");

            source.Solde -= montant;
            destination.Solde += montant;

            _compteRepo.Update(source);
            _compteRepo.Update(destination);
        }
    }
}
