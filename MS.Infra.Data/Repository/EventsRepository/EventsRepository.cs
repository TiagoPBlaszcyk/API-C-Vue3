using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MS.Domain.IEvents;
using MS.Entities.Events;
using MS.Infra.Data.Context;

namespace MS.Infra.Data.Repository.EventsRepository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public EventsRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventsVO>> FindAll(int userId)
        {
            List<Events> events = await _context.Events.Where(p => p.PersonId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<EventsVO>>(events);
        }

        public async Task<EventsVO> FindById(long id)
        {

            Events? events = await _context.Events.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (events == null) throw new InvalidOperationException($"Não encontrado!");
            
            return _mapper.Map<EventsVO>(events);
        }

        public async Task<EventsVO> Create(EventsVO vo)
        {
            vo.StartDay = Convert.ToDateTime(vo.StartDay);
            Events events = _mapper.Map<Events>(vo);
            _context.Events.Add(events);
            await _context.SaveChangesAsync();
            return _mapper.Map<EventsVO>(events);
        }

        public async Task<EventsVO> Update(EventsVO vo)
        {
            try
            {
                Events events = _mapper.Map<Events>(vo);
                _context.Events.Update(events);
                await _context.SaveChangesAsync();
                return _mapper.Map<EventsVO>(events);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Events events = await _context.Events.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (events == null) return false;
                _context.Events.Remove(events);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
