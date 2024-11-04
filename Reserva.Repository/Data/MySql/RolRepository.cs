using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class RolRepository : IRolRepository
    {
        private readonly ReservaContext _context;

        public RolRepository(ReservaContext context)
        {
            _context = context;
        }

        public void CreateRol(Rol rol)
        {
            _context.Add(rol);
            _context.SaveChanges();
        }

        public void DeleteRol(Rol rol)
        {
            _context.Update(rol);
            _context.SaveChanges();
        }

        public Rol GetRolById(int? id)
        {
            return _context.Rols.Where(r => r.EstId == 1).FirstOrDefault(m => m.IdRol == id);
        }

        public List<Rol> GetRoles()
        {
            return _context.Rols.Where(r => r.EstId == 1).ToList();
        }

        public bool RolExists(int id)
        {
            return _context.Rols.Any(m => m.IdRol == id);
        }

        public void UpdateRol(Rol rol)
        {
            _context.Update(rol);
            _context.SaveChanges();
        }
    }
}