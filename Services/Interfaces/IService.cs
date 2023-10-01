namespace ProvaPub.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        IList<T> GetAll();
    }
}
