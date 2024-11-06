using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL
{
    public class OrderDetailService
    {
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();

        public void AddOrderDetail(OrderDetail orderDetail) => _orderDetailRepo.CreateOrderDetail(orderDetail);
        public OrderDetail GetOrderDetailById(int id) => _orderDetailRepo.GetOrderDetailById(id);
        public bool UpdateOrderDetail(OrderDetail orderDetail) => _orderDetailRepo.UpdateOrderDetail(orderDetail);
        public bool DeleteOrderDetail(int id) => _orderDetailRepo.DeleteOrderDetail(id);
        public List<OrderDetail> GetAllOrderDetails() => _orderDetailRepo.GetAllOrderDetails();
        public List<OrderDetail> GetOrderDetailsByOrder(int orderId) => _orderDetailRepo.GetOrderDetailsByOrder(orderId);
    }

}
