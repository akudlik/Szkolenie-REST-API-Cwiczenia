namespace CwiczeniaRESTAPI.SeedWork
{
    public abstract class Entity
    {
        int _Id;
   
        public virtual int Id
        {
            get => _Id;
            protected set => _Id = value;
        }
    }
}