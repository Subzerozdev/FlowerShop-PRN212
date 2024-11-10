using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL
{
    public class OrderService
    {
        private readonly OrderRepo _orderRepo = new OrderRepo();

        public int AddOrder(Order order, List<OrderDetail> orderDetails) => _orderRepo.CreateOrder(order, orderDetails);
        public Order? GetOrderById(int id) => _orderRepo.GetOrderById(id);
        public bool UpdateOrder(Order order) => _orderRepo.UpdateOrder(order);
        public bool DeleteOrder(int id) => _orderRepo.DeleteOrder(id);
        public List<Order> GetAllOrders() => _orderRepo.GetAllOrders();
    }

}
