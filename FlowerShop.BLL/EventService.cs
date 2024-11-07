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

        public List<EventCategory> GetEventRepo()
        {
            return _eventRepo.GetEventcategories();
        }
        public EventCategory? GetEventCategory(int id)
        {
            return _eventRepo.GetEventcategory(id);
        }
        public void AddEventCategory(EventCategory category)
        {
            _eventRepo.AddEventcategory(category);
        }
        public void RemoveEventCategory(int id)
        {
            _eventRepo.RemoveEventcategory(id);
        }
        public bool UpdateEventCategory(EventCategory category)
        {
            return _eventRepo.UpdateEventcategory(category);
        }

    }
}
