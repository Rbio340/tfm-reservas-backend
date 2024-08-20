using Reserva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IReservaRepository
    {
        public List<Reservas> GetReserva();
        public List<Reservas> GetReservaById(int? id);
        public List<Reservas> GetHistorial(int id, DateTime fechaInicio, DateTime fechaFin);
        public void CreateReserva(Reservas reservas);
        public void UpdateReserva(Reservas reservas);
        public void DeleteReserva(Reservas reservas);
        public bool ReservaExists(int id);
    }
}
