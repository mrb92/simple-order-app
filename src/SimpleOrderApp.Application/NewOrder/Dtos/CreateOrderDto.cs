namespace SimpleOrderApp.Application.NewOrder.Dtos
{
    /// <summary>
    /// Create Order Dto
    /// </summary>
    public class CreateOrderDto
    {
        ///
        public string CustomerName { get; set; }

        ///
        public string CustomerPhone { get; set; }

        ///
        public DateTime StartDate { get; set; }

        ///
        public int ItemId { get; set; }
    }
}
