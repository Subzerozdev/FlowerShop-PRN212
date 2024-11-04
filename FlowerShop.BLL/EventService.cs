using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;

namespace FlowerShop.BLL
{
    public class EventService
    {
        private static EventRepo _eventRepo = new();

        public List<Eventcategory> GetEventRepo()
        {
            return _eventRepo.GetEventcategories();
        }
        public Eventcategory? GetEventCategory(int id)
        {
            return _eventRepo.GetEventcategory(id);
        }
        public void AddEventCategory(Eventcategory category)
        {
            _eventRepo.AddEventcategory(category);
        }
        public void RemoveEventCategory(int id)
        {
            _eventRepo.RemoveEventcategory(id);
        }
        public bool UpdateEventCategory(Eventcategory category)
        {
            return _eventRepo.UpdateEventcategory(category);
        }

    }
}
