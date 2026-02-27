using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.models
{
    public class Client
    {
        public int id{ get; set; }
        public string nom{ get; set; }
        public string prenom{ get; set; }
        public string telephone{ get; set; }
    }
}
