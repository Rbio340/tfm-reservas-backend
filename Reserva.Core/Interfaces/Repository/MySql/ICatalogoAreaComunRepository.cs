using Reserva.Core.Models;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface ICatalogoAreaComunRepository
    {
        public List<CatalogoAreaComun> GetCatalogoAreaComun();
        public CatalogoAreaComun GetCatalogoAreaComunById(int? id);
        public void CreateCatalogoAreaComun(CatalogoAreaComun catalogoArea);
        public void UpdateCatalogoAreaComun(CatalogoAreaComun catalogoArea);
        public void DeleteCatalogoAreaComun(CatalogoAreaComun catalogoArea);
        public bool CatalogoAreaComunExists(int id);
    }
}
