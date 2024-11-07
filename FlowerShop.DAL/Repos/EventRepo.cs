using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;

namespace FlowerShop.DAL.Repos
{
    public class EventRepo
    {
        private EventflowerexchangeContext _context;
        public EventRepo()
        {
            _context = new EventflowerexchangeContext();
        }
        public List<EventCategory> GetEventcategories()
        {
            return _context.EventCategories.ToList();
        }
        public EventCategory? GetEventcategory(int id)
        {
            return _context.EventCategories.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void AddEventcategory(EventCategory eventcategory)
        {
            _context.EventCategories.Add(eventcategory);
            _context.SaveChanges();
        }
        public bool RemoveEventcategory(int id)
        {
            bool result = false;
            EventCategory? eventcategory = GetEventcategory(id);
            if (eventcategory != null)
            {
                _context?.EventCategories.Remove(eventcategory);
                result = true;
            }
            return result;
        }
        public bool UpdateEventcategory(EventCategory eventcategory)
        {
            bool result = false;
            EventCategory? eventcategoryExisted = GetEventcategory(eventcategory.Id);
            if (eventcategoryExisted != null)
            {
                eventcategoryExisted.Name = eventcategory.Name;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
