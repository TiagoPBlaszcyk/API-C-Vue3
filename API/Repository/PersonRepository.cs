using API.Data.ValueObjects;
using API.Model;
using API.Model.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public PersonRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonVO>> FindAll()
        {
            List<Person> persons = await _context.Persons.ToListAsync();
            return _mapper.Map<List<PersonVO>>(persons);
        }

        public async Task<PersonVO> FindById(long id)
        {

            Person person = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (person == null) throw new InvalidOperationException($"Não encontrado!");
            
            return _mapper.Map<PersonVO>(person);
        }

        public async Task<Person> FindByName(string name)
        {

            Person person = await _context.Persons.Where(p => p.Name == name).FirstOrDefaultAsync();
            if (person == null) throw new ArgumentNullException(nameof(person));
            
            return _mapper.Map<Person>(person);
        }

        public async Task<PersonVO> Create(PersonVO vo)
        {
            if (vo.PermissaoId == null)
                vo.PermissaoId = 2;
            Person person = _mapper.Map<Person>(vo);
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonVO>(person);
        }

        public async Task<PersonVO> Update(PersonVO vo)
        {
            try
            {
                Person person = _mapper.Map<Person>(vo);
                _context.Persons.Update(person);
                await _context.SaveChangesAsync();
                return _mapper.Map<PersonVO>(person);
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
                Person person = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (person == null) return false;
                _context.Persons.Remove(person);
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
