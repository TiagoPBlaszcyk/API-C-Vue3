using System.Globalization;
using API.Data.ValueObjects;
using API.Model;
using API.Model.Context;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public EventsRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Events>> FindAll(int userId)
        {
            List<Events> events = await _context.Events.Where(p => p.PersonId == userId).ToListAsync();
            return _mapper.Map<List<Events>>(events);
        }

        public async Task<Events> FindById(long id)
        {

            Events events = await _context.Events.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (events == null) throw new InvalidOperationException($"Não encontrado!");
            
            return _mapper.Map<Events>(events);
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
