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
        private static ExContext _context;
        public EventRepo()
        {
            _context = new ExContext();
        }
        public List<Eventcategory> GetEventcategories()
        {
            return _context.Eventcategories.ToList();
        }
        public Eventcategory? GetEventcategory(int id)
        {
            return _context.Eventcategories.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void AddEventcategory(Eventcategory eventcategory)
        {
            _context.Eventcategories.Add(eventcategory);
            _context.SaveChanges();
        }
        public bool RemoveEventcategory(int id)
        {
            bool result = false;
            Eventcategory? eventcategory = GetEventcategory(id);
            if (eventcategory != null)
            {
                _context?.Eventcategories.Remove(eventcategory);
                result = true;
            }
            return result;
        }
        public bool UpdateEventcategory(Eventcategory eventcategory)
        {
            bool result = false;
            Eventcategory? eventcategoryExisted = GetEventcategory(eventcategory.Id);
            if (eventcategoryExisted != null) { 
                eventcategoryExisted.Name = eventcategory.Name;
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
