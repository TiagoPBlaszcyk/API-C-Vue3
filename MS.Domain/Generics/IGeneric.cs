namespace MS.Domain.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task<T> FindById(long id);
        Task<T> Create(T vo);
        Task<T> Update(T vo);
        Task<bool> Delete(long id);
    } 
}

