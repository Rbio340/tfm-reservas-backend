using Reserva.Core.Dto;
using Reserva.Core.Models;

namespace Reserva.Core.Interfaces.Repository.MySql
{
    public interface IAreaComunRepository
    {
        public List<AreaComunDto> GetAreasComun();
        public AreaComunDto GetAreaComunDtoById(int? id);
        public AreaComun GetAreaComunById(int? id);
        public void CreateAreaComun(AreaComun areaComun);
        public void UpdateAreaComun(AreaComun areaComun);
        public void DeleteAreaComun(AreaComun areaComun);
        public bool AreaComunExists(int id);
    }
}
