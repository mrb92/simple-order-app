namespace SimpleOrderApp.Application.OrderDetail.Dtos
{
    /// <summary>
    /// Get Order Detail Dto
    /// </summary>
    public class GetOrderDetailDto
    {
        ///
        public int Id { get; set; }

        ///
        public string Title { get; set; }

        ///
        public DateTime StartDate { get; set; }

        ///
        public DateTime? EndDate { get; set; }

        ///
        public decimal? Total { get; set; }
    }
}
