using API.Data.ValueObjects;
using API.Model;

namespace API.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonVO>> FindAll();
        Task<PersonVO> FindById(long id);
        Task<Person> FindByName(string name);
        Task<PersonVO> Create(PersonVO vo);
        Task<PersonVO> Update(PersonVO vo);
        Task<bool> Delete(long id);
    }
}
