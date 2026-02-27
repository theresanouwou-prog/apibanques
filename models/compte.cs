using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.models
{
    public class Compte
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Solde { get; set; }
        public string TypeCompte { get; set; }
    }
}
