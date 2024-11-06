using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DAL.Repos
{
    public class OrderDetailRepo
    {
        private static ExContext _context;

        public OrderDetailRepo()
        {
            _context = new ExContext();
        }
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }
        public OrderDetail GetOrderDetailById(int id)
        {
            return _context.OrderDetails.Include(od => od.Order).FirstOrDefault(od => od.Id == id);
        }
        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            bool result = false;
            var existingOrderDetail = _context.OrderDetails.Find(orderDetail.Id);
            if (existingOrderDetail != null)
            {
                _context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool DeleteOrderDetail(int id)
        {
            bool result = false;
            var orderDetail = _context.OrderDetails.Find(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.Include(od => od.Order).ToList();
        }
        public List<OrderDetail> GetOrderDetailsByOrder(int orderId)
        {
            return _context.OrderDetails
                           .Where(od => od.OrderId == orderId)
                           .Include(od => od.Order)
                           .ToList();
        }
    }
}
