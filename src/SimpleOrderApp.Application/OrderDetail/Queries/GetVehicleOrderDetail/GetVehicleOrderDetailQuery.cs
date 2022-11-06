using MediatR;
using SimpleOrderApp.Application.ListOrder.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetVehicleOrderDetail
{
    public class GetVehicleOrderDetailQuery
    {
        public int Id { get; set; }
    }

    //public class GetVehicleOrderDetailQueryHandler : IRequestHandler<GetVehicleOrderDetailQuery, GetOrdersDto>
}
