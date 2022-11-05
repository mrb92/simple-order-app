namespace SimpleOrderApp.Domain.Entities.Referentials
{
    public class RefVehicleType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
