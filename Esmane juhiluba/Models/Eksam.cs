using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmane_juhiluba.Models
{
    public class Eksam
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }
        public int Tervisekontroll { get; set; } = -1;
        public int Teooria { get; set; } = -1;
        public int Sõidu { get; set; } = -1;
        public int Luba { get; set; } = -1;
    }
}
