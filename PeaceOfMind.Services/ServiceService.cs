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

        public ServiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateService(ServiceCreate model)
        {
            var entity =
                new Service()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Minutes = model.Minutes,
                    MinMinutes = model.MinMinutes,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Services
                        .Select(
                            e =>
                                new ServiceListItem
                                {
                                    ServiceId = e.ServiceId,
                                    Name = e.Name,
                                    Price = e.Price,
                                    Minutes = e.Minutes,
                                    MinMinutes = e.MinMinutes,
                                    Description = e.Description
                                }
                        );

                return query.ToArray();
            }
        }

        public ServiceDetail GetServiceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Services
                        .Single(e => e.ServiceId == id);
                return
                    new ServiceDetail
                    {
                        ServiceId = entity.ServiceId,
                        Name = entity.Name,
                        Price = entity.Price,
                        Minutes = entity.Minutes,
                        MinMinutes = entity.MinMinutes,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateNote(ServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Services
                        .Single(e => e.ServiceId == model.ServiceId);

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Minutes = model.Minutes;
                entity.MinMinutes = model.MinMinutes;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Services
                        .Single(e => e.ServiceId == serviceId);

                ctx.Services.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
