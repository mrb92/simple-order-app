namespace SimpleOrderApp.Application.ListOrder.Queries.GetOrders
{
    /// <summary>
    /// Represents the information for the orders page
    /// </summary>
    public class GetOrdersDto
    {
        /// <summary>
        /// List of orders
        /// </summary>
        public List<GetOrderDto> Orders { get; set; }
    }
}
