namespace Domain.entities.baseEntities
{
    public abstract class BaseModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }


        protected void SetUpdatedAt()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}