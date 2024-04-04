using Reserva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IEstadoRepository
    {
        public List<Estado> GetEstado();
        public Estado GetEstadoById(int? id);
        public void CreateEstado (Estado estado);
        public void UpdateEstado (Estado estado);
        public void DeleteEstado (Estado estado);
        public bool EstadoExists(int id);
    }
}
