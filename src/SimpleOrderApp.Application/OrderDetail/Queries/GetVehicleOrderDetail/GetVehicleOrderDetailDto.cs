using SimpleOrderApp.Application.OrderDetail.Dtos;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetVehicleOrderDetail
{
    public class GetVehicleOrderDetailDto : GetOrderDetailDto
    {
        public bool? IsTankFull { get; set; }

        public bool? IsCarIntact { get; set; }

        public decimal? PricePerDay { get; set; }
    }
}
