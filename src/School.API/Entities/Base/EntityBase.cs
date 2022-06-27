namespace School.API.Entities.Base
{    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime Register { get; protected set; }

        protected EntityBase()
        {
            Register = DateTime.UtcNow;
        }

        public abstract void Update(string name, bool registered);
    }
}
