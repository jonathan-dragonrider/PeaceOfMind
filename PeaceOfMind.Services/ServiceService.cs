using PeaceOfMind.Data;
using PeaceOfMind.Models;
using PeaceOfMind.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeaceOfMind.Services
{
    public class ServiceService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ServiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateService(ServiceCreate model)
        {
            var entity = new Service
            {
                Name = model.Name,
                Cost = model.Cost,
                Duration = model.Duration,
                DurationUnit = model.DurationUnit,
                Description = model.Description
            };

            _context.Services.Add(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            return _context.Services.Select(e => new ServiceListItem
            {
                ServiceId = e.ServiceId,
                Name = e.Name
            }).ToArray();
        }

        public ServiceDetail GetServiceById(int id)
        {
            var entity = _context.Services.Find(id);

            return new ServiceDetail
            {
                ServiceId = entity.ServiceId,
                Name = entity.Name,
                Cost = entity.Cost,
                Duration = entity.Duration,
                DurationUnit = entity.DurationUnit,
                Description = entity.Description
            };
        }

        public bool UpdateService(ServiceEdit model)
        {
            var entity = _context.Services.Find(model.ServiceId);

            entity.Name = model.Name;
            entity.Cost = model.Cost;
            entity.Duration = model.Duration;
            entity.DurationUnit = model.DurationUnit;
            entity.Description = model.Description;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteService(int id)
        {
            _context.Services.Remove(_context.Services.Find(id));
            return _context.SaveChanges() == 1;
        }
    }
}
