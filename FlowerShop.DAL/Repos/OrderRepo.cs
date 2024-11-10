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
        private EventflowerexchangeContext? _context;
        public int CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            _context = new();
            int newOrderId = _context.Orders.OrderByDescending(o => o.Id).FirstOrDefault().Id + 1;
            order.Id = newOrderId;
            order.Status = "Đang xử lí";
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
            return order.Id;
        }
        public Order? GetOrderById(int id)
        {
            _context=new();
            return _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
        }
        public bool UpdateOrder(Order order)
        {
            _context=new();
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
            _context=new();
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
            _context = new();
            return _context.Orders.Include(o => o.OrderDetails).ToList();
        }
    }
}
