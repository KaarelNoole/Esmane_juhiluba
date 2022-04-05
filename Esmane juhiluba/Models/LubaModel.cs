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
        public int Teooria { get; set; }
        public int Sõidupäevik { get; set; }
        public string Sõidu { get; set; }
        public string Luba { get; set; }
    }
}
