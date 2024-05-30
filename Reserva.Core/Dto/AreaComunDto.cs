using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva.Core.Dto
{
    public class AreaComunDto
    {
        public int EspId { get; set; }
        public string EspNombre { get; set; }
        public int CatespId { get; set; }
        public string CatespNombre { get; set; }
        public int EstId { get; set; }
        public string EstNombre { get; set; }
    }
}
