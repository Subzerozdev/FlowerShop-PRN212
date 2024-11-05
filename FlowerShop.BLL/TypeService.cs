using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;

namespace FlowerShop.BLL
{
    public class TypeService
    {
        private static TypeRepo _repo = new();
        public List<FlowerType> GetFlowerTypes()
        {
            return _repo.GetAllTypes();
        } 
        public FlowerType? GetFlowerType(int id)
        {
            return _repo.GetFlowerType(id);
        }
        public bool UpdateFLowerType(FlowerType type)
        {
            return _repo.UpdateType(type);
        }
        public bool DeleteFLowerType(int id)
        {
            return _repo.DeleteType(id);
        }
    }
}
