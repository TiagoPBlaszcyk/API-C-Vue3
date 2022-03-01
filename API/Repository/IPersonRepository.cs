using API.Data.ValueObjects;

namespace API.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonVO>> FindAll();
        Task<PersonVO> FindById(long id);
        Task<PersonVO> Create(PersonVO vo);
        Task<PersonVO> Update(PersonVO vo);
        Task<bool> Delete(long id);
    }
}
