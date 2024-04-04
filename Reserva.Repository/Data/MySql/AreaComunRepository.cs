using Microsoft.EntityFrameworkCore;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Repository.Context;

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
            return _context.AreaComuns.Include(a => a.Catesp).Include(a => a.Est).ToList();
        }

        public AreaComun GetAreaComunById(int? id)
        {
            return _context.AreaComuns.Include(a => a.Catesp).Include(a => a.Est).FirstOrDefault(m => m.EspId == id);
        }

        public void UpdateAreaComun(AreaComun areaComun)
        {
            _context.Update(areaComun);
            _context.SaveChanges();
        }
    }
}
