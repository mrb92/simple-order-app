using SimpleOrderApp.Application.OrderDetail.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetVehicleOrderDetail
{
    public class GetVehicleOrderDetailDto : GetOrderDetailDto
    {
        public bool? IsTankFull { get; set; }
    }
}
