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
        private static ExContext _context;

        public OrderRepo()
        {
            _context = new ExContext();
        }
        public void CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var detail in orderDetails)
            {
                detail.OrderId = order.Id;
                _context.OrderDetails.Add(detail);
            }
            _context.SaveChanges();
        }
        public Order GetOrderById(int id)
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
