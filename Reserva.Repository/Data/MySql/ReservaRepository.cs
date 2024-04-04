using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ReservaContext _context;

        public ReservaRepository(ReservaContext context) 
        {
            _context = context;
        }

        public void CreateReserva(Reservas reservas)
        {
            _context.Add(reservas);
            _context.SaveChanges();
        }

        public void DeleteReserva(Reservas reservas)
        {
            _context.Remove(reservas);
            _context.SaveChanges();
        }

        public List<Reservas> GetReserva()
        {
            return _context.Reservas.ToList();
        }

        public Reservas GetReservaById(int? id)
        {
            return _context.Reservas.FirstOrDefault(m => m.ResId == id);
        }

        public bool ReservaExists(int id)
        {
            return _context.Reservas.Any(m => m.ResId == id);
        }

        public void UpdateReserva(Reservas reservas)
        {
            _context.Update(reservas);
            _context.SaveChanges();
        }
    }
}
