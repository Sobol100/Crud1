using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud1.Models
{
    public class DowolnaKlasaModel
    {
        public int Id { get; set; }

        public int PhoneNumber { get; set; }

        public string Nickname { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public virtual ICollection<DrugaKlasaModel> DrugaKlasaModel { get; set; }


    }
}
