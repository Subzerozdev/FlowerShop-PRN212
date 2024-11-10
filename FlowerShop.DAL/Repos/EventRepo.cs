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
        private EventflowerexchangeContext? _context;
        public List<EventCategory> GetEventcategories()
        {
            _context = new();
            return _context.EventCategories.ToList();
        }
        public EventCategory? GetEventcategory(int id)
        {
            _context=new();
            return _context.EventCategories.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void AddEventcategory(EventCategory eventcategory)
        {
            _context= new();
            _context.EventCategories.Add(eventcategory);
            _context.SaveChanges();
        }
        public bool RemoveEventcategory(int id)
        {
            _context= new();
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
            _context= new();
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
