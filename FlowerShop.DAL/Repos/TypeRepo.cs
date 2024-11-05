using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;

namespace FlowerShop.DAL.Repos
{
    public class TypeRepo
    {
        private static ExContext _context;
        public TypeRepo()
        {
            _context = new ExContext();
        }
        public List<FlowerType> GetAllTypes()
        {
            return _context.Types.ToList();
        }
        public FlowerType? GetFlowerType(int id)
        {
            return _context.Types.FirstOrDefault(t => t.Id == id);
        }
        public void CreateType(FlowerType type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
        }
        public bool DeleteType(int id)
        {
            bool result = false;
            FlowerType? type = GetFlowerType(id);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateType(FlowerType type)
        {
            bool result = false;
            FlowerType? typeExisted = GetFlowerType(type.Id);
            if (typeExisted != null)
            {
                typeExisted.Name = type.Name;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
