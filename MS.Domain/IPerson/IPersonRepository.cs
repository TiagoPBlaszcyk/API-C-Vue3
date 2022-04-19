using MS.Entities.Person;

namespace MS.Domain.IPerson;

public interface IPersonRepository
{
    Task<IEnumerable<PersonVO>> FindAll();
    Task<PersonVO> FindById(long id);
    Task<Person> FindByName(string name);
    Task<PersonVO> Create(PersonVO vo);
    Task<PersonVO> Update(PersonVO vo);
    Task<bool> Delete(long id);
}
