using Reserva.Core.Dto;
using Reserva.Core.Models;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IAreaComunRepository
    {
        public List<AreaComunDto> GetAreasComun();
        public AreaComunDto GetAreaComunById(int? id);
        public void CreateAreaComun(AreaComun areaComun);
        public void UpdateAreaComun(AreaComun areaComun);
        public void DeleteAreaComun(AreaComunDto areaComun);
        public bool AreaComunExists(int id);
    }
}
