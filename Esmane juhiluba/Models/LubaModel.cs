using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esmane_juhiluba.Models
{
    public class LubaModel
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }
        public int Tervisekontroll { get; set; }
        public int Teooria { get; set; }
        public int Sõidu { get; set; }
        public int Luba { get; set; }
    }
}
