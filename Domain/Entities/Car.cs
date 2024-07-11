using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : BaseEntity<Guid>
    {
        // UUID
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public Guid BrandId { get; set; } // veritabanı ilişkiyi kuracak alan
        public virtual Brand Brand { get; set; } = default!; // oop konseptlerini kullanabilmek için sanal alan.
    }
}
