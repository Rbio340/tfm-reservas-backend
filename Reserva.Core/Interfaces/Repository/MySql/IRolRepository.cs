using Reserva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IRolRepository
    {
        public List<Rol> GetRoles();
        public Rol GetRolById(int? id);
        public void CreateRol(Rol rol);
        public void UpdateRol(Rol rol);
        public void DeleteRol(Rol rol);
        public bool RolExists(int id);
    }
}
