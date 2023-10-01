namespace ProvaPub.Models.abstracts
{
    public abstract class ModelList<T> where T : class
    {
        public IList<T> Items { get; set; }
        public int TotalCount { get; }
        public bool HasNext { get; }

        protected ModelList(IList<T> items)
        {
            Items = items;
            TotalCount = items.Count();
            HasNext = TotalCount == 10;
        }
    }
}
