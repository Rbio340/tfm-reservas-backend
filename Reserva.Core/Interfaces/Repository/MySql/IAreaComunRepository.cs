using Reserva.Core.Models;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IAreaComunRepository
    {
        public List<AreaComun> GetAreasComun();
        public AreaComun GetCambioById(int? id);
        public void CreateAreaComun(AreaComun areaComun);
        public void UpdateAreaComun(AreaComun areaComun);
        public void DeleteAreaComun(AreaComun areaComun);
        public bool AreaComunExists(int id);
    }
}
