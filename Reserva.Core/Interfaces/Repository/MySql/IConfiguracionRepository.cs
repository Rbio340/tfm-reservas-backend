using Reserva.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IConfiguracionRepository
    {
        public List<Configuracion> GetConfiguracion();
        public Configuracion GetConfiguracionById(int? id);
        public void CreateConfiguracion(Configuracion configuracion);
        public void UpdateConfiguracion(Configuracion configuracion);
        public void DeleteConfiguracion(Configuracion configuracion);
        public bool ConfiguracionExists(int id);
    }
}
