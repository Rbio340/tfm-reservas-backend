using Microsoft.EntityFrameworkCore;
using Reserva.Core.Dto;
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
            areaComun.EstId = 1;
            _context.Add(areaComun);
            _context.SaveChanges();
        }

        public void DeleteAreaComun(AreaComun areaComun)
        {
            _context.Update(areaComun);
            _context.SaveChanges();
        }

        public List<AreaComunDto> GetAreasComun()
        {
            var areasComun = _context.AreaComunDtos.FromSqlRaw("CALL GetAreaComunDetails()").ToList();
            return areasComun;
        }

        public AreaComun GetAreaComunById(int? id)
        {
            var areaComun = _context.AreaComuns.FirstOrDefault(a => a.EspId == id);
            return areaComun;
        }

        public void UpdateAreaComun(AreaComun areaComun)
        {
            areaComun.EstId = 1;
            _context.Update(areaComun);
            _context.SaveChanges();
        }

        public AreaComunDto GetAreaComunDtoById(int? id)
        {
            var areaComun = _context.AreaComunDtos.FromSqlRaw("CALL GetAreaComunDetails()")
            .AsEnumerable()
            .FirstOrDefault(a => a.EspId == id);
            return areaComun;
        }
    }
}
