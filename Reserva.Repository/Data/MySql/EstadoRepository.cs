using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ReservaContext _context;

        public EstadoRepository(ReservaContext context)
        {
            _context = context;
        }

        public void CreateEstado(Estado estado)
        {
            _context.Add(estado);
            _context.SaveChanges();
        }

        public void DeleteEstado(Estado estado)
        {
            _context.Remove(estado);
            _context.SaveChanges();
        }

        public bool EstadoExists(int id)
        {
            return _context.Estados.Any(m => m.EstId== id);
        }

        public List<Estado> GetEstado()
        {
           var estados = _context.Estados.ToList();
            return estados;
        }

        public Estado GetEstadoById(int? id)
        {
            return _context.Estados.FirstOrDefault(m => m.EstId == id);
        }

        public void UpdateEstado(Estado estado)
        {
            _context.Update(estado);
            _context.SaveChanges();
        }
    }
}