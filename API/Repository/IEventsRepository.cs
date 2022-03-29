using API.Data.ValueObjects;
using API.Model;

namespace API.Repository
{
    public interface IEventsRepository
    {
        Task<IEnumerable<Events>> FindAll(int userID);
        Task<Events> FindById(long id);
        Task<EventsVO> Create(EventsVO vo);
        Task<EventsVO> Update(EventsVO vo);
        Task<bool> Delete(long id);
    }
}
