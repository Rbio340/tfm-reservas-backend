﻿using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

namespace Reserva.Repository.Data.MySql
{
    public class ConfiguracionRepository : IConfiguracionRepository
    {
        private readonly ReservaContext _context;

        public ConfiguracionRepository(ReservaContext reservaContext)
        {
            _context = reservaContext;
        }

        public bool ConfiguracionExists(int id)
        {
            return _context.Configuracion.Any(m => m.ConfigId == id);
        }

        public void CreateConfiguracion(Configuracion configuracion)
        {
            configuracion.ConfigId = null;
            _context.Add(configuracion);
            _context.SaveChanges();
        }

        public void DeleteConfiguracion(Configuracion configuracion)
        {
            _context.Remove(configuracion);
            _context.SaveChanges();
        }

        public List<Configuracion> GetConfiguracion()
        {
            return _context.Configuracion.ToList();
        }

        public Configuracion GetConfiguracionById(int? id)
        {
            return _context.Configuracion.FirstOrDefault(m => m.EspId == id);
        }

        public void UpdateConfiguracion(Configuracion configuracion)
        {
            _context.Update(configuracion);
            _context.SaveChanges();
        }
    }
}
