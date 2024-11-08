using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DAL.Repos
{
    public class OrderRepo
    {
        private EventflowerexchangeContext _context;

        public OrderRepo()
        {
            _context = new EventflowerexchangeContext();
        }
        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            int newOrderId = _context.Orders.OrderByDescending(o => o.Id).FirstOrDefault().Id+1;
            order.Id = newOrderId;
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var detail in orderDetails)
            {
                long newOrderDetailId = _context.OrderDetails.OrderByDescending(o => o.Id).FirstOrDefault().Id + 1;
                detail.Id = newOrderDetailId;
                detail.OrderId = order.Id;
            }
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();
            return true;
        }
        public Order? GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
        }
        public bool UpdateOrder(Order order)
        {
            bool result = false;
            var existingOrder = _context.Orders.Find(order.Id);
            if (existingOrder != null)
            {
                _context.Entry(existingOrder).CurrentValues.SetValues(order);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteOrder(int id)
        {
            bool result = false;
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.OrderDetails).ToList();
        }
    }
}
