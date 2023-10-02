namespace ProvaPub.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        bool Create(T model);
    }
}
