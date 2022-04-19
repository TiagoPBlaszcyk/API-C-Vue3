using MS.Entities.Events;

namespace MS.Domain.IEvents;

public interface IEventsRepository
{ 
    Task<IEnumerable<EventsVO>> FindAll(int userID);
    Task<EventsVO> FindById(long id);
    Task<EventsVO> Create(EventsVO vo);
    Task<EventsVO> Update(EventsVO vo);
    Task<bool> Delete(long id);
}