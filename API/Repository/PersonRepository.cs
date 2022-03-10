using API.Data.ValueObjects;
using API.Model;
using API.Model.Context;
using AutoMapper;
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
            List<Person> products = await _context.Persons.ToListAsync();
            return _mapper.Map<List<PersonVO>>(products);
        }

        public async Task<PersonVO> FindById(long id)
        {

            Person product = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null) throw new ArgumentNullException(nameof(product));
            
            return _mapper.Map<PersonVO>(product);
        }

        public async Task<PersonVO> FindByName(string name)
        {

            Person product = await _context.Persons.Where(p => p.Name == name).FirstOrDefaultAsync();
            if (product == null) throw new ArgumentNullException(nameof(product));
            
            return _mapper.Map<PersonVO>(product);
        }

        public async Task<PersonVO> Create(PersonVO vo)
        {
            Person product = _mapper.Map<Person>(vo);
            _context.Persons.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<PersonVO>(product);
        }

        public async Task<PersonVO> Update(PersonVO vo)
        {
            try
            {
                Person product = _mapper.Map<Person>(vo);
                _context.Persons.Update(product);
                await _context.SaveChangesAsync();
                return _mapper.Map<PersonVO>(product);
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
                Person product = await _context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null) return false;
                _context.Persons.Remove(product);
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
