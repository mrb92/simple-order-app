namespace SimpleOrderApp.Application.OrderDetail.Dtos
{
    public class GetVehicleOrderDetailDto : GetOrderDetailDto
    {
        public bool? IsTankFull { get; set; }

        public bool? IsCarIntact { get; set; }

        public decimal? PricePerDay { get; set; }
    }
}
