namespace WebApplication15.Models.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
        public virtual int Id { get; set; }
    }
}