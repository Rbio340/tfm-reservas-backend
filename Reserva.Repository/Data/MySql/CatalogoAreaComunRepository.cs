using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Repository.Context;
using Reserva.Core.Models;

namespace Reserva.Repository.Data.MySql
{
    public class CatalogoAreaComunRepository : ICatalogoAreaComunRepository
    {
        private readonly ReservaContext _context;

        public CatalogoAreaComunRepository(ReservaContext context)
        {
            _context = context;
        }

        public bool CatalogoAreaComunExists(int id)
        {
            return _context.CatalogoAreaComuns.Any(m => m.CatespId == id);

        }

        public void CreateCatalogoAreaComun(CatalogoAreaComun catalogoArea)
        {
            catalogoArea.EstId = 1;
            _context.Add(catalogoArea);
            _context.SaveChanges();
        }

        public void DeleteCatalogoAreaComun(CatalogoAreaComun catalogoArea)
        {
            _context.Update(catalogoArea);
            _context.SaveChanges();
        }

        public List<CatalogoAreaComun> GetCatalogoAreaComun()
        {
            return _context.CatalogoAreaComuns.Where(m => m.EstId==1).ToList();
        }

        public CatalogoAreaComun GetCatalogoAreaComunById(int? id)
        {
            return _context.CatalogoAreaComuns.Where(m=> m.EstId == 1 ).FirstOrDefault(m => m.CatespId == id);
        }

        public void UpdateCatalogoAreaComun(CatalogoAreaComun catalogoArea)
        {
            catalogoArea.EstId = 1;
            _context.Update(catalogoArea);
            _context.SaveChanges();
        }
    }
}
