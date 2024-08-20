using Microsoft.EntityFrameworkCore;
using Mysqlx.Cursor;
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
            reservas.EstId = 1;
            _context.Add(reservas);
            _context.SaveChanges();
        }

        public void DeleteReserva(Reservas reservas)
        {
            _context.Update(reservas);
            _context.SaveChanges();
        }

        public List<Reservas> GetReserva()
        {
            return _context.Reservas.Include(r => r.Esp).Include(r => r.Usu).Where(r => r.EstId == 1).ToList();
        }

        public List<Reservas> GetReservaById(int? id)
        {
            return _context.Reservas.Include(r => r.Esp)
                .Include(r => r.Usu).Where(r=> r.EstId==1 && r.EspId == id).ToList();
        }
        public List<Reservas> GetHistorial(int id, DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Reservas.Include(r => r.Esp)
                .Include(r => r.Usu).Where(r => r.EstId == 1 && r.UsuId == id && (r.ResFecha<= fechaFin && r.ResFecha>= fechaInicio)).ToList();
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