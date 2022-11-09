namespace SimpleOrderApp.Application.ListOrder.Queries.GetOrders
{
    /// <summary>
    /// Represents a single order
    /// </summary>
    public class GetOrderDto
    {
        ///
        public int Id { get; set; }

        ///
        public string Title { get; set; }

        ///
        public int TypeId { get; set; }

        ///
        public DateTime StartDate { get; set; }

        ///
        public DateTime? EndDate { get; set; }

        ///
        public string CustomerName { get; set; }
    }
}
