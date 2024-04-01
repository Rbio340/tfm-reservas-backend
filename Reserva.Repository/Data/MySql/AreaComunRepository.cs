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
    public class AreaComunRepository : IAreaComunRepository
    {
        private readonly ReservaContext _context;

        public AreaComunRepository(ReservaContext context)
        {
            _context = context;
        }

        public bool AreaComunExists(int id)
        {
            return _context.AreaComuns.Any(m => m.EspId == id);
        }

        public void CreateAreaComun(AreaComun areaComun)
        {
            _context.Add(areaComun);
            _context.SaveChanges();
        }

        public void DeleteAreaComun(AreaComun areaComun)
        {
            _context.Remove(areaComun);
            _context.SaveChanges();
        }

        public List<AreaComun> GetAreasComun()
        {
            return _context.AreaComuns.ToList();
        }

        public AreaComun GetCambioById(int? id)
        {
            return _context.AreaComuns.FirstOrDefault(m => m.EspId == id);
        }

        public void UpdateAreaComun(AreaComun areaComun)
        {
            _context.Update(areaComun);
            _context.SaveChanges();
        }
    }
}
