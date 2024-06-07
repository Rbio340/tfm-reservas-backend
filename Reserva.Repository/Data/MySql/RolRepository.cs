using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void DeleteRol(Rol rol)
        {
            throw new NotImplementedException();
        }

        public Rol GetRolById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> GetRoles()
        {
            throw new NotImplementedException();
        }

        public bool RolExists(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRol(Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
