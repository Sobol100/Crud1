using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud1.Models
{
    public class DrugaKlasaModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public uint Pesel { get; set; }

        public uint Age { get; set; }
    }
}
