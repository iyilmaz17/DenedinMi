using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    // Tüm entityler için ortak olabilecek özellikler bu interface üzerinden eklenebilir.
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
