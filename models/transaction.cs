using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CompteSourceId { get; set; }
        public int? CompteDestinationId { get; set; }
        public decimal Montant { get; set; }
        public string TypeTransaction { get; set; }
        public DateTime DateTransaction { get; set; }
    }
}
