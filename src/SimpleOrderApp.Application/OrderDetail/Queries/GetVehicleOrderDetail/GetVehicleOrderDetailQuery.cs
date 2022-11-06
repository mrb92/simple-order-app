using MediatR;
using SimpleOrderApp.Application.ListOrder.Queries.List;
using SimpleOrderApp.Application.NewOrder.Queries.GetVehicleFilters;
using SimpleOrderApp.Application.OrderDetail.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOrderApp.Application.OrderDetail.Queries.GetVehicleOrderDetail
{
    public class GetVehicleOrderDetailQuery : IRequest<GetOrderDetailDto>
    {
        public int Id { get; set; }
    }

    //public class GetVehicleOrderDetailQueryHandler : IRequestHandler<GetVehicleOrderDetailQuery, GetOrdersDto>
}
