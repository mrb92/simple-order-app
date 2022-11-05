namespace SimpleOrderApp.Domain.Entities.Referentials
{
    public class RefOrderType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
